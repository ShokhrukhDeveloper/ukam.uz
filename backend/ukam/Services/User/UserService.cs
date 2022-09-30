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
    public async ValueTask<Result<User>> CreateAsync(User model)
    {
        
        var createdEntity = new Backend.Uckam.Entities.User(model, "url", ToEntityLanguage(model.Language), ToEntityRole(model.Role));

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

    private User ToModel(Entities.User entity)
    => new()
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        LastName = entity.LastName,
        UserName = entity.UserName,
        Role = ToModelERole(entity.Role),
        Language = ToModelELanguage(entity.Language),
        CreatedAt = entity.CreatedAt,
        UpdatedAt = entity.UpdatedAt,
    };

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

    public ValueTask<Result<User>> GetByIdAsync(ulong id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Result<User>> RemoveByIdAsync(ulong id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Result<User>> UpdateAsync(User model)
    {
        throw new NotImplementedException();
    }
}