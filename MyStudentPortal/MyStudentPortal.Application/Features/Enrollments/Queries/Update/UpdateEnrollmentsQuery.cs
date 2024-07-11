using AutoMapper;
using MediatR;
using MyStudentPortal.Application.Features.Enrollments.Queries.Update;
using MyStudentPortal.Application.Repositories.Interfaces;
using MyStudentPortal.Domain.Entities;

namespace MyStudentPortal.Application.Features.Enrollments.Queries
{
    public record UpdateEnrollmentsQuery : IRequest<IList<UpdateEnrollmentsDto>>
    {
        /// <summary>
        /// Gets the update student dto.
        /// </summary>
        /// <value>
        /// The update student dto.
        /// </value>
        public IList<UpdateEnrollmentsDto> UpdateEnrollmentsDto { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateEnrollmentsQuery"/> class.
        /// </summary>
        /// <param name="updateEnrollmentsDto">The update enrollments dto.</param>
        public UpdateEnrollmentsQuery(IList<UpdateEnrollmentsDto> updateEnrollmentsDto)
        {
            UpdateEnrollmentsDto = updateEnrollmentsDto;
        }
    }

    public class UpdateEnrollmentsQueryHandler : IRequestHandler<UpdateEnrollmentsQuery, IList<UpdateEnrollmentsDto>>
    {
        #region Private Fields

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateApplicationUserQueryHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        public UpdateEnrollmentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Handles the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IList<UpdateEnrollmentsDto>> Handle(UpdateEnrollmentsQuery query, CancellationToken cancellationToken)
        {
            //Map
            var enrollment = _mapper.Map<Enrollment>(query.UpdateEnrollmentsDto);

            //get course by id
            enrollment.Course = await _unitOfWork.Repository<Course>().GetByIdAsync(enrollment.CourseId);
            //get student by id
            //enrollment.ApplicationUser = await _unitOfWork.Repository<Student>().GetByIdAsync(enrollment.StudentId);
            //Update
            await _unitOfWork.Repository<Enrollment>().UpdateAsync(enrollment);
            await _unitOfWork.SaveAsync(cancellationToken);

            //Return
            return _mapper.Map<IList<UpdateEnrollmentsDto>>(enrollment);
        }

        #endregion Public Methods
    }
}