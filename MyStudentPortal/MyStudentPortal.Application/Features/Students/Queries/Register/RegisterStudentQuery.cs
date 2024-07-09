using AutoMapper;
using MediatR;
using MyStudentPortal.Application.Repositories.Interfaces;
using MyStudentPortal.Domain.Entities;

namespace MyStudentPortal.Application.Features.Students.Queries.Register
{
    public record RegisterStudentQuery : IRequest<StudetDto>
    {
        /// <summary>
        /// Gets or sets the register studet dto.
        /// </summary>
        /// <value>
        /// The register studet dto.
        /// </value>
        public StudetDto StudetDto { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterStudentQuery"/> class.
        /// </summary>
        /// <param name="studetDto">The studet dto.</param>
        public RegisterStudentQuery(StudetDto studetDto)
        {
            this.StudetDto = studetDto;
        }
    }

    public class RegisterStudentQueryHandler : IRequestHandler<RegisterStudentQuery, StudetDto>
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
        /// Initializes a new instance of the <see cref="RegisterStudentQueryHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        public RegisterStudentQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
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
        public async Task<StudetDto> Handle(RegisterStudentQuery query, CancellationToken cancellationToken)
        {
            var newStudent = _mapper.Map<Student>(query.StudetDto);

            var results = await _unitOfWork.Repository<Student>().AddAsync(newStudent);
            await _unitOfWork.SaveAsync(cancellationToken);

            return _mapper.Map<StudetDto>(results);
        }

        #endregion Public Methods
    }
}