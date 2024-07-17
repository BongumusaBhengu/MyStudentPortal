using MyStudentPortal.Application.Features.Courses;
using MyStudentPortal.Domain.Entities;

namespace MyStudentPortal.Application.Features.Enrollments.Queries
{
    public class EnrollmentsDto
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the courses.
        /// </summary>
        /// <value>
        /// The courses.
        /// </value>
        public IList<CourseDto>? Courses { get; set; }

        /// <summary>
        /// Gets or sets the enrollment date.
        /// </summary>
        /// <value>
        /// The enrollment date.
        /// </value>
        public DateTime EnrollmentDate { get; set; }


        /// <summary>
        /// Gets or sets the application user.
        /// </summary>
        /// <value>
        /// The application user.
        /// </value>
        public ApplicationUser? ApplicationUser { get; set; }

        #endregion Public Properties
    }
}