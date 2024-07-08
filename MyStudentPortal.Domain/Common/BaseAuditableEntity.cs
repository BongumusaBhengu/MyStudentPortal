using MyStudentPortal.Domain.Common;
using MyStudentPortal.Domain.Common.Interfaces;

namespace MyStudentPortal.Domain.Entities
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="BaseEntity" />
    /// <seealso cref="IAuditableEntity" />
    public abstract class BaseAuditableEntity : BaseEntity, IAuditableEntity
    {
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate => DateTime.Now;
        public int? UpdatedBy { get; set; }
        public DateTime UpdatedDate => DateTime.Now;
    }
}