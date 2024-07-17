using MyStudentPortal.Domain.Entities;

namespace MyStudentPortal.Application.Repositories.Interfaces
{
    public interface IEnrollmentRepository
    {
        /// <summary>
        /// Gets all for student.
        /// </summary>
        /// <param name="studentId">The student identifier.</param>
        /// <returns></returns>
        Task<IList<Enrollment>> GetAllForStudent(string studentId);
    }
}