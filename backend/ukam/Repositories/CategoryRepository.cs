namespace Backend.Uckam.Repositories;
using Backend.Uckam.Entities;
public class CategoryRepository:GenericRepository<Category>{
    public CategoryRepository(AppDbContext dbContext):base(dbContext){}
}