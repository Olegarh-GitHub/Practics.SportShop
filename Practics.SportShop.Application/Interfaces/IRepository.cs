using System.Linq.Expressions;
using Practics.SportShop.Domain.Models.Base;

namespace Practics.SportShop.Application.Interfaces;

public interface IRepository<TEntity>
    where TEntity : Entity
{
    public Task InsertAsync(TEntity entity);
    public Task InsertAsync(List<TEntity> entities);

    public Task UpdateAsync(TEntity entity);
    public Task UpdateAsync(List<TEntity> entities);

    public Task<List<TEntity>> ReadAsync(params Expression<Func<TEntity, bool>>[] selectors);
    public IQueryable<TEntity> Read();

    public Task DeleteAsync(TEntity entity);
    public Task DeleteAsync(List<TEntity> entities);
}