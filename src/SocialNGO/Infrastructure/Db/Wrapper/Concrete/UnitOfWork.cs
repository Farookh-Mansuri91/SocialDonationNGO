using Microsoft.EntityFrameworkCore.Storage;
using SocialNGO.Infrastructure.db.Wrapper.Contracts;
using SocialNGO.Infrastructure.Db;
using SocialNGO.Infrastructure.Db.Repositories.Base.Concrete;
using SocialNGO.Infrastructure.Db.Repositories.Base.Contracts;

namespace SocialNGO.Infrastructure.db.Wrapper.Concrete;

/// <summary> </summary>
public class UnitOfWork : IUnitOfWorks
{
    private readonly ApplicationDBContext dbContext;
    private readonly IDbContextTransaction transaction;
    private readonly ILogger<UnitOfWork> logger;
    private bool _disposed;

    private readonly Dictionary<Type, object> _repositories;

    /// <summary></summary>
    /// <param name="_dbContext"></param>
    /// <param name="_logger"></param>
    public UnitOfWork(ApplicationDBContext _dbContext, ILogger<UnitOfWork> _logger)
    {
        dbContext = _dbContext;
        transaction = dbContext.Database.BeginTransaction();
        _repositories = new Dictionary<Type, object>();
        logger = _logger;
    }

    /// <summary> </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class
    {
        if (_repositories.ContainsKey(typeof(TEntity)))
        {
            return _repositories[typeof(TEntity)] as IBaseRepository<TEntity>;
        }

        var repository = new BaseRepository<TEntity>(dbContext);
        _repositories.Add(typeof(TEntity), repository);
        return repository;
    }

    /// <summary> </summary>
    /// <param name="cancellationToken"></param>
    /// <param name="clearChangeTracker"></param>
    /// <returns></returns>
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default, bool clearChangeTracker = false)
    {
        try
        {
            int noOfRowAffected = await dbContext.SaveChangesAsync(cancellationToken);
            transaction.Commit();
            if (clearChangeTracker)
                dbContext.ChangeTracker.Clear();

            return noOfRowAffected;
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            logger.LogError(ex?.ToString());
            throw;
            // You might want to handle or log the exception as needed
        }
    }

    /// <summary> </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary> </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                foreach (var repository in _repositories.Values)
                {
                    (repository as IDisposable)?.Dispose();
                }
                // Dispose repositories if necessary
            }
            _disposed = true;
        }
    }
}
