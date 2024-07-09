namespace MyStudentPortal.Domain.Entities
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="BaseAuditableEntity" />
    public class Student : BaseAuditableEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the enrollments.
        /// </summary>
        /// <value>
        /// The enrollments.
        /// </value>
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the identity number.
        /// </summary>
        /// <value>
        /// The identity number.
        /// </value>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        #endregion Public Properties
    }
}