namespace MyStudentPortal.Domain.Entities
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="BaseAuditableEntity" />
    public class Course : BaseAuditableEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the enrollments.
        /// </summary>
        /// <value>
        /// The enrollments.
        /// </value>
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}