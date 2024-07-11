using MyStudentPortal.Domain.Entities;

namespace MyStudentPortal.Application.Repositories.Interfaces
{
    public interface IApplicationUserRepository
    {
        #region Public Methods

        /// <summary>
        /// Creates the application user.
        /// </summary>
        /// <param name="applicationUser">
        /// The application user.
        /// </param>
        /// <returns>
        ///   <br />
        /// </returns>
        Task<ApplicationUser?> CreateAsync(ApplicationUser applicationUser);

        /// <summary>
        /// Deletes the application user.
        /// </summary>
        /// <param name="id">
        /// The identifier.
        /// </param>
        /// <returns>
        ///   <br />
        /// </returns>
        Task<bool> DeleteByIdAsync(int id);

        /// <summary>
        /// Gets all application users.
        /// </summary>
        /// <returns></returns>
        Task<List<ApplicationUser>> GetAllAsync();

        /// <summary>
        /// Gets the application user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<ApplicationUser?> GetByIdAsync(int id);

        /// <summary>
        /// Gets the name of the application user by user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        Task<ApplicationUser> GetByUserNameAsync(string userName);

        /// <summary>
        /// Updates the application user.
        /// </summary>
        /// <param name="applicationUserDto">The application user dto.</param>
        /// <returns></returns>
        Task<ApplicationUser> UpdateAsync(ApplicationUser applicationUserDto);

        #endregion Public Methods
    }
}