using MyStudentPortal.Application.Repositories.Interfaces;
using MyStudentPortal.Domain.Entities;
using MyStudentPortal.Persistence.Contexts;

namespace MyStudentPortal.Persistence.Repositories
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationUserRepository"/> class.
    /// </summary>
    /// <param name="dbContext">The database context.</param>
    public class ApplicationUserRepository(StudentPortalDBContext dbContext) : IApplicationUserRepository
    {
        #region Private Fields

        /// <summary>
        /// The database context
        /// </summary>
        private readonly StudentPortalDBContext _dbContext = dbContext;

        #endregion Private Fields

        #region Public Methods

        public async Task<ApplicationUser?> CreateAsync(ApplicationUser applicationUser)
        {
            await _dbContext.Set<ApplicationUser>().AddAsync(applicationUser);
            return applicationUser;
        }

        public Task<bool> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ApplicationUser>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<ApplicationUser>().FindAsync(id);
        }

        public Task<ApplicationUser> GetByUserNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> UpdateAsync(ApplicationUser applicationUserDto)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}