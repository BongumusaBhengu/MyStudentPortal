using AutoMapper;
using MediatR;
using MyStudentPortal.Application.Repositories.Interfaces;
using MyStudentPortal.Domain.Entities;

namespace MyStudentPortal.Application.Features.Enrollments.Queries.Create
{
    public record CreateEnrollmentsQuery : IRequest<IList<EnrollmentsDto>>
    {
        /// <summary>
        /// Gets or sets the course dto.
        /// </summary>
        /// <value>
        /// The course dto.
        /// </value>
        public CourseDto CourseDto { get; set; } = new CourseDto();

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEnrollmentsQuery" /> class.
        /// </summary>
        /// <param name="studentId">The student identifier.</param>
        /// <param name="courseDtos">The course dtos.</param>
        public CreateEnrollmentsQuery(int studentId, CourseDto courseDtos)
        {
            CourseDto.StudentId = studentId;
            CourseDto = courseDtos;
        }
    }

    public class CreateEnrollmentsQueryHandler : IRequestHandler<CreateEnrollmentsQuery, IList<EnrollmentsDto>>
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

        /// <summary>
        /// The enrollment repository
        /// </summary>
        private readonly IEnrollmentRepository _enrollmentRepository;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateApplicationUserQueryHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        public CreateEnrollmentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IEnrollmentRepository enrollmentRepository)
        {
            _unitOfWork = unitOfWork;
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
        public async Task<IList<EnrollmentsDto>> Handle(CreateEnrollmentsQuery query, CancellationToken cancellationToken)
        {
            //TODO: This is a bit too expensive this can be simplified.
            var student = await _unitOfWork.Repository<Student>().GetByIdAsync(query.CourseDto.StudentId);

            var courses = (from courseId in query.CourseDto.Id
                           let course = _unitOfWork.Repository<Course>().GetByIdAsync(courseId)
                           where course != null
                           select course).ToList();

            foreach (var enrollment in from course in courses
                                       let enrollment = new Enrollment()
                                       {
                                           Course = course.Result,
                                           CourseId = course.Id,
                                           EnrollmentDate = DateTime.Now,
                                           StudentId = student.Id,
                                           Student = student,
                                       }
                                       select enrollment)
            {
                await _unitOfWork.Repository<Enrollment>().AddAsync(enrollment);
            }

            await _unitOfWork.SaveAsync(cancellationToken);

            var studentEnrollments = await _enrollmentRepository.GetAllForStudent(student.Id);

            //Return
            return _mapper.Map<IList<EnrollmentsDto>>(studentEnrollments);
        }

        #endregion Public Methods
    }
}