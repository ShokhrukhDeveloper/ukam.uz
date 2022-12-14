using Backend.Uckam.data;

namespace Backend.Uckam.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IUSerRepository Users { get; set; }
    public ICategoryRepository Categories { get; set; }
    public IBookRepository Books { get; set; }
    public ICategoryTypeRepository CategoryTypes { get; set; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Users = new UserRepository(context);
        Categories= new CategoryRepository(context);
        Books = new BookRepository(context);
        CategoryTypes = new CategoryTypeRepository(context);
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public int Save() => _context.SaveChanges();
}