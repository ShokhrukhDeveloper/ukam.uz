using Backend.Uckam.Models;
using ukam.Models;

namespace Backend.Uckam.Services;
public interface ICategoryTypeService
{
    public ValueTask<Result<List<CategoryType>>> GetAllAsync();
    public ValueTask<Result<CategoryType>> GetByIdAsync(ulong categoryTypeId);
    public ValueTask<Result<CategoryType>> DeleteCategoryType(ulong categoryTypeId);
    public ValueTask<Result<CategoryType>> UpdateCategoryType(ulong categoryTypeId, ulong userId, ulong categoryId, string name);
    public ValueTask<Result<CategoryType>> CreateCategoryType(ulong categoryId, ulong creatorId, string name);
}

