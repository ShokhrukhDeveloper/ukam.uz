using Backend.Uckam.Models;

namespace Backend.Uckam.Services;

public interface IUserService
{
    ValueTask<Result<List<User>>> GetAllUsersAsync(int page = 1, int limit = 10);
    ValueTask<Result<List<User>>> GetAllAdminsAsync(int page = 1, int limit = 10);
    ValueTask<Result<User>> GetByIdAsync(ulong id);
    ValueTask<Result<User>> CreateAsync(User model, IFormFile file);
    ValueTask<Result<User>> UpdateAsync(ulong id, User model, IFormFile file);
    ValueTask<bool> ExistsAsync(ulong id);
}