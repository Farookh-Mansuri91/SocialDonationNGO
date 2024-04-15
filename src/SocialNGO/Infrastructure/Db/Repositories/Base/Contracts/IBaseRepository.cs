using System.Linq.Expressions;

namespace SocialNGO.Infrastructure.Db.Repositories.Base.Contracts;

/// <summary> </summary>
public interface IBaseRepository<TEntity> : IDisposable
{
    /// <summary> </summary>
    /// <returns></returns>
    IQueryable<TEntity> GetAll();

    /// <summary> </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    Task<TEntity?> GetById(Expression<Func<TEntity, bool>> expression);

    /// <summary> </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task Create(TEntity entity);

    /// <summary> </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task Update(TEntity entity);

    /// <summary> </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task Delete(TEntity entity);

    /// <summary> </summary>
    void Dispose();
}
