using MyStudentPortal.Application.Repositories.Interfaces;
using MyStudentPortal.Domain.Entities;
using MyStudentPortal.Persistence.Contexts;
using System.Collections;

namespace MyStudentPortal.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Private Fields

        /// <summary>
        /// The database context
        /// </summary>
        private readonly StudentPortalDBContext _dbContext;

        /// <summary>
        /// The repositories
        /// </summary>
        private Hashtable? _repositories;

        /// <summary>
        /// The disposed
        /// </summary>
        private bool disposed;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <exception cref="System.ArgumentNullException">dbContext</exception>
        public UnitOfWork(StudentPortalDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Repositories this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity
        {
            _repositories ??= new Hashtable();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<T>)_repositories[type];
        }

        /// <summary>
        /// Rollbacks this instance.
        /// </summary>
        /// <returns></returns>
        public Task Rollback()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());

            return Task.CompletedTask;
        }

        /// <summary>
        /// Saves the specified cancellation token.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<int> SaveAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Saves the and remove cache.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="cacheKeys">The cache keys.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed && disposing)
            {
                //dispose managed resources
                _dbContext.Dispose();
            }
            //dispose unmanaged resources
            disposed = true;
        }

        #endregion Protected Methods
    }
}