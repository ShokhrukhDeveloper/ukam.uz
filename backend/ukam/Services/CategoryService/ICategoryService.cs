using Backend.Uckam.Models;
using ukam.Models;

namespace ukam.Services.CategoryService;
public interface ICategoryService
{
    public ValueTask<Result<List<Category>>> GetAllAsync();
    public ValueTask<Result<Category>> GetByIdAsync(ulong categoryId);
    public ValueTask<Result<Category>> DeleteCategory(ulong categoryId,ulong userId);
    public ValueTask<Result<Category>> UpdateCategory(ulong categoryId, ulong userId, Category category, IFormFile? formFile=null);
    public ValueTask<Result<Category>> CreateCategory(Category category, IFormFile? formFile=null);

}

