using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyStudentPortal.Application.Features;
using MyStudentPortal.Application.Features.Enrollments.Queries;
using MyStudentPortal.Application.Features.Enrollments.Queries.Create;
using MyStudentPortal.Application.Features.Enrollments.Queries.Get;
using MyStudentPortal.Application.Features.Enrollments.Queries.Update;

namespace MyStudentPortal.API.Controllers
{
    [Route("[controller]")]
    public class EnrollmentController : ControllerBase
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
        public EnrollmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="courseDto">The course dto.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("create/{studentId}")]
        public async Task<IActionResult> CreateAsync(int studentId, [FromBody] CourseDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _mediator.Send(new CreateEnrollmentsQuery(studentId, courseDto)));
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("get/{studentId}")]
        public async Task<IActionResult> GetAsync(int studentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _mediator.Send(new GetEnrollmentsQuery(studentId)));
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="updateEnrollmentsDto">The update enrollments dto.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] IList<UpdateEnrollmentsDto> updateEnrollmentsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _mediator.Send(new UpdateEnrollmentsQuery(updateEnrollmentsDto)));
        }

        #endregion Public Methods
    }
}