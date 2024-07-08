using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MyStudentPortal.API.Controllers
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseController : ControllerBase
    {
        #region Protected Fields

        /// <summary>
        /// The mediator
        /// </summary>
        protected readonly IMediator Mediator;

        #endregion Protected Fields

        #region Protected Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        protected BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }

        #endregion Protected Constructors
    }
}