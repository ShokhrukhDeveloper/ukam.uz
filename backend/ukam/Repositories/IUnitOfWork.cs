namespace Backend.Uckam.Repositories;

public interface IUnitOfWork : IDisposable
{
    IUSerRepository Users { get; set; }
    ICategoryRepository Categories { get; set; }
    int Save();
}