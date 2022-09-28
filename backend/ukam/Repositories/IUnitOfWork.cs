namespace Backend.Uckam.Repositories;

public interface IUnitOfWork : IDisposable
{
    IUSerRepository Users { get; set; }
    int Save();
}