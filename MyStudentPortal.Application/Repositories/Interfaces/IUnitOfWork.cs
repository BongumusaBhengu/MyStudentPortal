using MyStudentPortal.Domain.Entities;

namespace MyStudentPortal.Application.Repositories.Interfaces
{
    /// <summary>
    /// This interface defines a unit of work pattern that allows us to save changes made by multiple repositories at once.
    /// </summary>
    /// <seealso cref="IDisposable" />
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Repositories this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity;

        /// <summary>
        /// Saves the specified cancellation token.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> SaveAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Saves the and remove cache.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="cacheKeys">The cache keys.</param>
        /// <returns></returns>
        Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys);

        /// <summary>
        /// Rollbacks this instance.
        /// </summary>
        /// <returns></returns>
        Task Rollback();
    }
}