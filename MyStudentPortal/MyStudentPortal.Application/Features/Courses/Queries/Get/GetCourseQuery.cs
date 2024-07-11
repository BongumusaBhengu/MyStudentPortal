using AutoMapper;
using MediatR;
using MyStudentPortal.Application.Repositories.Interfaces;
using MyStudentPortal.Domain.Entities;

namespace MyStudentPortal.Application.Features.Courses
{
    public record GetCourseQuery : IRequest<IList<CourseDto>>;

    /// <param name="mapper">
    /// The mapper
    /// </param>
    /// <param name="unitOfWork">
    /// The unit of work
    /// </param>
    public class GetCourseQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<GetCourseQuery, IList<CourseDto>>
    {

        #region Public Methods

        /// <summary>
        /// Handles the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IList<CourseDto>> Handle(GetCourseQuery query, CancellationToken cancellationToken)
        {
            var courses = await unitOfWork.Repository<Course>().GetAllAsync();

            //Return
            return mapper.Map<IList<CourseDto>>(courses);
        }

        #endregion Public Methods
    }
}