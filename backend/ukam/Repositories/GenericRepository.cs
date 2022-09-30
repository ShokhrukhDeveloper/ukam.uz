#pragma warning disable
using Backend.Uckam.data;

namespace Backend.Uckam.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext _context;

    public GenericRepository(AppDbContext context) => _context = context;
    public async ValueTask<TEntity> AddAsync(TEntity entity)
    {
        var entry = await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();

        return entry.Entity;
    }

    public async ValueTask AddRange(IEnumerable<TEntity> entities)
    {
        await _context.Set<TEntity>().AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public IQueryable<TEntity> GetAll() => _context.Set<TEntity>();

    public TEntity GetById(ulong id) => _context.Set<TEntity>().Find(id);

    public async ValueTask<TEntity> Remove(TEntity entity)
    {
        var entry = _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();

        return entry.Entity;
    }

    public async ValueTask RemoveRange(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().RemoveRange(entities);

        await _context.SaveChangesAsync();
    }

    public async ValueTask<TEntity> Update(TEntity entity)
    {
        var entry = _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();

        return entry.Entity;
    }
}