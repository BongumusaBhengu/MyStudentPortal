using Microsoft.EntityFrameworkCore;
using MyStudentPortal.Application.Repositories.Interfaces;
using MyStudentPortal.Domain.Entities;
using MyStudentPortal.Persistence.Contexts;

namespace MyStudentPortal.Persistence.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        #region Private Fields

        /// <summary>
        /// The database context
        /// </summary>
        private readonly StudentPortalDBContext _dbContext;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EnrollmentRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public EnrollmentRepository(StudentPortalDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Gets all for student.
        /// </summary>
        /// <param name="studentId">The student identifier.</param>
        /// <returns></returns>
        public async Task<List<Enrollment>> GetAllForStudent(int studentId)
        {
            return await _dbContext.Enrollments
                .Where(e => e.StudentId == studentId)
                .ToListAsync();
        }

        #endregion Public Methods
    }
}