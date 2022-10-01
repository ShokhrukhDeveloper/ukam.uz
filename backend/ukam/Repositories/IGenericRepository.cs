#pragma warning disable
using System.Linq.Expressions;

namespace Backend.Uckam.Repositories;

public interface IGenericRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> GetAll();
    TEntity GetById(ulong id);
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
    ValueTask<TEntity> AddAsync(TEntity entity);
    ValueTask<TEntity> Update(TEntity entity);
    ValueTask<TEntity> Remove(TEntity entity);
    ValueTask AddRange(IEnumerable<TEntity> entities);
    ValueTask RemoveRange(IEnumerable<TEntity> entities);
}