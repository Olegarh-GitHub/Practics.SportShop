using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Practics.SportShop.Application.Interfaces;
using Practics.SportShop.Domain.Models.Base;

namespace Practics.SportShop.Infrastructure.Repositories;

public class Repository<TContext, TEntity> : IRepository<TEntity> 
    where TContext : DbContext
    where TEntity : Entity
{
    protected readonly TContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public Repository(TContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task InsertAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Added;

        await _dbSet.AddAsync(entity);

        await _context.SaveChangesAsync();
    }

    public async Task InsertAsync(List<TEntity> entities)
    {
        entities.ForEach(entity => _context.Entry(entity).State = EntityState.Added);

        await _dbSet.AddRangeAsync(entities);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;

        _dbSet.Update(entity);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(List<TEntity> entities)
    {
        entities.ForEach(entity => _context.Entry(entity).State = EntityState.Modified);

        _dbSet.UpdateRange(entities);

        await _context.SaveChangesAsync();
    }

    public async Task<List<TEntity>> ReadAsync(params Expression<Func<TEntity, bool>>[] selectors)
    {
        IQueryable<TEntity> query = _dbSet.AsQueryable();
        
        selectors.ToList().ForEach(selector => query = query.Where(selector));

        return await query.ToListAsync();
    }

    public IQueryable<TEntity> Read()
    {
        return _dbSet.AsQueryable();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;

        _dbSet.Remove(entity);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(List<TEntity> entities)
    {
        entities.ForEach(entity => _context.Entry(entity).State = EntityState.Deleted);

        _dbSet.RemoveRange(entities);

        await _context.SaveChangesAsync();
    }
}