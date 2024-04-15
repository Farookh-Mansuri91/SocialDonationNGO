using SocialNGO.Infrastructure.Db.Repositories.Base.Contracts;

namespace SocialNGO.Infrastructure.db.Wrapper.Contracts;

/// <summary> </summary>
public interface IUnitOfWorks : IDisposable
{
    /// <summary>
    /// Save Modified, Added, Deleted Enties
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <param name="clearChangeTracker"></param>
    /// <returns>Row Affected</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default, bool clearChangeTracker = false);

    /// <summary>Get All repositories and register</summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
}
