using Microsoft.EntityFrameworkCore;

namespace BankAPI.Infrastructure.DataAccess.Common.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public Repository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }
    
    public IQueryable<T> Query()
    {
        return _dbSet;
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        if (entity is null)
        {
            throw new ArgumentNullException();
        }

        await _dbSet.AddAsync(entity, cancellationToken);
    }

    public Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        if (entity is null)
        {
            throw new ArgumentNullException();
        }

        _dbSet.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(T entity, CancellationToken cancellationToken)
    {
        if (entity is null)
        {
            throw new ArgumentNullException();
        }

        _dbSet.Remove(entity);
        return Task.CompletedTask;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}