#pragma warning disable

using Backend.Uckam.Models;
using Backend.Uckam.Repositories;

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

    public ValueTask<Result<List<User>>> GetAllAdminsAsync(int page = 1, int limit = 10)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Result<List<User>>> GetAllUsersAsync(int page = 1, int limit = 10)
    {
        throw new NotImplementedException();
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