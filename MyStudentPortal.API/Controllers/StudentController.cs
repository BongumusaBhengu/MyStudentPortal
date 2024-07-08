using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyStudentPortal.Application.Features.Students.Queries;
using MyStudentPortal.Application.Features.Students.Queries.Register;
using MyStudentPortal.Application.Features.Students.Queries.Update;

namespace MyStudentPortal.API.Controllers
{
    [Route("[controller]")]
    public class StudentController : ControllerBase
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
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="studetDto">The studet dto.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] StudetDto studetDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _mediator.Send(new RegisterStudentQuery(studetDto)));
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

            return Ok(await _mediator.Send(new GetStudentByIdQuery(id)));
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

            return Ok(await _mediator.Send(new DeleteStudentUserQuery(id)));
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="studetDto">The studet dto.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateStudentDto updateStudentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _mediator.Send(new UpdateStudentQuery(updateStudentDto)));
        }

        #endregion Public Methods
    }
}