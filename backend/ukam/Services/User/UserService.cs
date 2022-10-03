#pragma warning disable

using Backend.Uckam.Models;
using Backend.Uckam.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Uckam.Services;
public partial class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UserService> _logger;

    public UserService(ILogger<UserService> logger, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
    public async ValueTask<Result<User>> CreateAsync(User model, IFormFile? file = null)
    {
        var fileHelper = new FileHelper();
        string fileName = null;

        if (file is not null)
            if (!fileHelper.FileValidateImage(file))
                return new("File is invalid");

        if (file != null)
            fileName = fileHelper.WriteFileAsync(file, FileFolders.UserImage).Result;

        var createdEntity = new Backend.Uckam.Entities.User(model, fileName, ToEntityLanguage(model.Language), ToEntityRole(model.Role));

        try
        {
            var createdUser = await _unitOfWork.Users.AddAsync(createdEntity);

            return new(true) { Data = ToModel(createdUser) };
        }
        catch (Exception e)
        {
            _logger.LogInformation($"Error occured at {nameof(UserService)}");
            throw new("Couldn't create User, Contact support", e);
        }
    }

    public ValueTask<bool> ExistsAsync(ulong id)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<Result<List<User>>> GetAllPaginatedAdminsAsync(int page = 1, int limit = 10)
    {
         try
        {
            var existingTopics = _unitOfWork.Users.GetAll().Where(u => u.Role.ToString() == "Admin" && u.Role.ToString() == "Super Admin" );
            
            if(existingTopics is null)
                return new("No users found. Contact support.");

            var filteredTopics = await existingTopics
                .Skip((page - 1) * limit)
                .Take(limit)
                .Select(e => ToModel(e))
                .ToListAsync();
            
            return new(true) { Data = filteredTopics };
        }
        catch(Exception e)
        {
            _logger.LogError($"Error occured at {nameof(UserService)}", e);
            throw new("Couldn't get topics. Contact support.", e);
        }     
    }

    public async ValueTask<Result<List<User>>> GetAllPaginatedUsersAsync(int page = 1, int limit = 10)
    {
       try
        {
            var existingUsers = _unitOfWork.Users.GetAll();
            
            if(existingUsers is null)
                return new("No users found. Contact support.");

            var filteredUsers = await existingUsers
                .Select(u => ToModel(u))
                .ToListAsync();
            
            return new(true) { Data = filteredUsers };
        }
        catch(Exception e)
        {
            _logger.LogError($"Error occured at {nameof(UserService)}", e);
            throw new("Couldn't get users. Contact support.", e);
        }       
    }

    public async ValueTask<Result<User>> GetByIdAsync(ulong id)
    {
        try
        {
            var existingUser = _unitOfWork.Users.GetAll().FirstOrDefault(t => t.Id == id);

            if (existingUser is null)
                return new("User with given ID not found.");

            return new(true) { Data = ToModel(existingUser) };
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured at {nameof(UserService)}", e);
            throw new("Couldn't get user. Contact support.", e);
        }
    }

    public async ValueTask<Result<User>> UpdateAsync(ulong id, User model, IFormFile? file = null)
    {
        string? fileName = null;
        var existingUser = _unitOfWork.Users.GetById(id);
        var fileHelper = new FileHelper();

        if (existingUser is null)
            return new("User with given ID not found.");

        if (file is not null)
            if (!fileHelper.FileValidateImage(file))
                return new("File is invalid");

        if (existingUser.UserPath != null)
            if (!fileHelper.DeleteFileByName(existingUser.UserPath))
                return new("File is not availabe");

        if (file != null)
            fileName = await fileHelper.WriteFileAsync(file, FileFolders.UserImage);

        existingUser.FirstName = model.FirstName;
        existingUser.LastName = model.LastName;
        existingUser.UserName = model.UserName;
        existingUser.Balance = model.Balance;
        existingUser.PasswordHash = model.PasswordHash;
        existingUser.UserPath = model.UserImage;
        existingUser.Language = ToEntityLanguage(model.Language);
        existingUser.UserPath = fileName;

        try
        {
            var createdUser = await _unitOfWork.Users.Update(existingUser);

            return new(true) { Data = ToModel(createdUser) };
        }
        catch (Exception e)
        {
            _logger.LogInformation($"Error occured at {nameof(UserService)}");
            throw new("Couldn't create User, Contact support", e);
        }
    }
}