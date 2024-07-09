using MyStudentPortal.Application.Repositories.Interfaces;
using MyStudentPortal.Domain.Entities;
using MyStudentPortal.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStudentPortal.Persistence.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {

        #region Private Fields

        /// <summary>
        /// The database context
        /// </summary>
        private readonly StudentPortalDBContext _dbContext;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public ApplicationUserRepository(StudentPortalDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion Public Constructors

        #region Public Methods

        public Task<ApplicationUser> CreateAsync(ApplicationUser applicationUser)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ApplicationUser>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
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