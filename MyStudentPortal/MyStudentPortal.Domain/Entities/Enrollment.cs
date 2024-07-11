namespace MyStudentPortal.Domain.Entities
{
    public class Enrollment : BaseAuditableEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the application user.
        /// </summary>
        /// <value>
        /// The application user.
        /// </value>
        public ApplicationUser? ApplicationUser { get; set; }

        /// <summary>
        /// Gets or sets the course.
        /// </summary>
        /// <value>
        /// The course.
        /// </value>
        public Course? Course { get; set; }

        /// <summary>
        /// Gets or sets the course identifier.
        /// </summary>
        /// <value>
        /// The course identifier.
        /// </value>
        public int CourseId { get; set; }

        /// <summary>
        /// Gets or sets the enrollment date.
        /// </summary>
        /// <value>
        /// The enrollment date.
        /// </value>
        public DateTime EnrollmentDate { get; set; }

        /// <summary>
        /// Gets or sets the student identifier.
        /// </summary>
        /// <value>
        /// The student identifier.
        /// </value>
        public string StudentId { get; set; }

        #endregion Public Properties
    }
}