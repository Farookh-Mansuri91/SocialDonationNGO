using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using SocialNGO.Infrastructure.Db;
using SocialNGO.Infrastructure.Db.Repositories.Base.Contracts;

namespace SocialNGO.Infrastructure.Db.Repositories.Base.Concrete;

/// <summary> </summary>
/// <remarks> </remarks>
/// <param name="dbContext"></param>
public class BaseRepository<TEntity>(ApplicationDBContext dbContext) : IBaseRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDBContext _dbContext = dbContext;

    /// <summary> </summary>
    /// <returns></returns>
    public IQueryable<TEntity> GetAll()
    {
        return _dbContext.Set<TEntity>().AsNoTracking();
    }

    /// <summary> </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public async Task<TEntity?> GetById(Expression<Func<TEntity, bool>> expression)
    {
        return await _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(expression);
    }

    /// <summary> </summary>
    public async Task Create(TEntity entity)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
    }

    /// <summary> </summary>
    /// <param name="entity"></param>
    public async Task Update(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    /// <summary> </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    /// <summary> </summary>
    public void Dispose()
    {
        _dbContext.Dispose();
    }
}