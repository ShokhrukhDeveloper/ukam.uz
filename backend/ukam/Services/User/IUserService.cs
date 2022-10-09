using Backend.Uckam.Models;

namespace Backend.Uckam.Services;

public interface IUserService
{
    ValueTask<Result<List<User>>> GetAllPaginatedAdminsAsync(int page = 1, int limit = 10);
    ValueTask<Result<List<User>>> GetAllPaginatedUsersAsync(int page = 1, int limit = 10);
    ValueTask<Result<User>> GetByIdAsync(ulong id);
    ValueTask<Result<User>> UpdateAsync(ulong id, User model, IFormFile file);
    ValueTask<Result<User>> CreateAsync(User model, IFormFile file);
    ValueTask<Result<User>> ChangeUserOrAdminAsync(ulong id, ERole role);
    ValueTask<Result<User>> UserBlock(ulong id, bool block);
    ValueTask<bool> ExistsAsync(ulong id);
}