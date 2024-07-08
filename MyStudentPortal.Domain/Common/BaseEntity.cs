using MyStudentPortal.Domain.Common.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStudentPortal.Domain.Common
{
    /// <summary>
    /// BaseEntity class that implements the IEntity interface
    /// </summary>
    /// <seealso cref="IEntity" />
    public abstract class BaseEntity : IEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}