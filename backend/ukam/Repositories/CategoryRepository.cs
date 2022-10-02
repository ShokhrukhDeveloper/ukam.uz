namespace Backend.Uckam.Repositories;

using Backend.Uckam.data;
using Backend.Uckam.Entities;


public class CategoryRepository:GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext dbContext):base(dbContext){}
}