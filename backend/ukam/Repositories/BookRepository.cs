namespace Backend.Uckam.Repositories;

using Backend.Uckam.data;
using Backend.Uckam.Entities;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(AppDbContext context) : base(context)
    {
    }
}