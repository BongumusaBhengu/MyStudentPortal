using MediatR;

namespace MyStudentPortal.API.Controllers
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="BaseController" />
    public class CourseController : BaseController
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public CourseController(IMediator mediator) : base(mediator)
        {
        }

        #endregion Public Constructors
    }
}