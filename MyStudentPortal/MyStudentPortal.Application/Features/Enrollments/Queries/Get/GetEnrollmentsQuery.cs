using AutoMapper;
using MediatR;
using MyStudentPortal.Application.Repositories.Interfaces;

namespace MyStudentPortal.Application.Features.Enrollments.Queries.Get
{
    public record GetEnrollmentsQuery : IRequest<IList<EnrollmentsDto>>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string StudentId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetEnrollmentsQuery"/> class.
        /// </summary>
        /// <param name="studentId">The student identifier.</param>
        public GetEnrollmentsQuery(string studentId)
        {
            StudentId = studentId;
        }
    }

    public class GetEnrollmentsQueryHandler : IRequestHandler<GetEnrollmentsQuery, IList<EnrollmentsDto>>
    {
        #region Private Fields

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The enrollment repository
        /// </summary>
        private readonly IEnrollmentRepository _enrollmentRepository;

        #endregion Private Fields

        #region Public Constructors

        public GetEnrollmentsQueryHandler(IMapper mapper, IEnrollmentRepository enrollmentRepository)
        {
            _mapper = mapper;
            _enrollmentRepository = enrollmentRepository;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Handles the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IList<EnrollmentsDto>> Handle(GetEnrollmentsQuery query, CancellationToken cancellationToken)
        {
            var studentEnrollments = await _enrollmentRepository.GetAllForStudent(query.StudentId);

            //Return
            return _mapper.Map<IList<EnrollmentsDto>>(studentEnrollments);
        }

        #endregion Public Methods
    }
}