using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyStudentPortal.Application.Features.Users;
using MyStudentPortal.Application.Features.Users.Queries;

namespace MyStudentPortal.API.Controllers
{
    [Route("[controller]")]
    public class ApplicationUserController : ControllerBase
    {
        #region Private Fields

        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator _mediator;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public ApplicationUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="applicationUserDto">The application user dto.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] ApplicationUserDto applicationUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _mediator.Send(new CreateApplicationUserQuery(applicationUserDto)));
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _mediator.Send(new GetUserApplicationUserByIdQuery(id)));
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _mediator.Send(new DeleteApplicationUserQuery(id)));
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="applicationUserDto">The application user dto.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] ApplicationUserDto applicationUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _mediator.Send(new UpdateApplicationUserQuery(applicationUserDto)));
        }

        #endregion Public Methods
    }
}