using Backend.Uckam.data;
using Backend.Uckam.Entities;

namespace Backend.Uckam.Repositories;

public class CategoryTypeRepository : GenericRepository<CategoryType>, ICategoryTypeRepository
{
    public CategoryTypeRepository(AppDbContext context) : base(context) { }
}