using Backend.Uckam.data;

namespace Backend.Uckam.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IUSerRepository Users { get; set; }
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Users = new UserRepository(context);
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public int Save() => _context.SaveChanges();
}