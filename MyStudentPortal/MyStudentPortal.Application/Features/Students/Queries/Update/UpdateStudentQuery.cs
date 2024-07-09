using AutoMapper;
using MediatR;
using MyStudentPortal.Application.Features.Students.Queries.Update;
using MyStudentPortal.Application.Repositories.Interfaces;
using MyStudentPortal.Domain.Entities;

namespace MyStudentPortal.Application.Features.Students.Queries
{
    public record UpdateStudentQuery : IRequest<StudetDto>
    {
        /// <summary>
        /// Gets the student dto.
        /// </summary>
        /// <value>
        /// The student dto.
        /// </value>
        public UpdateStudentDto UpdateStudentDto { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateStudentQuery"/> class.
        /// </summary>
        /// <param name="updateStudentDto">The update student dto.</param>
        public UpdateStudentQuery(UpdateStudentDto updateStudentDto)
        {
            UpdateStudentDto = updateStudentDto;
        }
    }

    public class UpdateStudentQueryHandler : IRequestHandler<UpdateStudentQuery, StudetDto>
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
        public UpdateStudentQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
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
        public async Task<StudetDto> Handle(UpdateStudentQuery query, CancellationToken cancellationToken)
        {
            //Map
            var student = _mapper.Map<Student>(query.UpdateStudentDto);

            //Update
            await _unitOfWork.Repository<Student>().UpdateAsync(student);
            await _unitOfWork.SaveAsync(cancellationToken);

            //Return
            return _mapper.Map<StudetDto>(student);
        }

        #endregion Public Methods
    }
}