namespace Backend.Uckam.Repositories;

public interface IUnitOfWork : IDisposable
{
    IUSerRepository Users { get; set; }
    ICategoryRepository Categories { get; set; }
    IBookRepository Books { get; set; }
    int Save();
}