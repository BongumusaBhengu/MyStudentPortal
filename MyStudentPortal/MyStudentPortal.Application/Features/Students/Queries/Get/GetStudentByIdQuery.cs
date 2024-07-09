using AutoMapper;
using MediatR;
using MyStudentPortal.Application.Repositories.Interfaces;
using MyStudentPortal.Domain.Entities;

namespace MyStudentPortal.Application.Features.Students.Queries
{
    public record GetStudentByIdQuery : IRequest<StudetDto>
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetStudentByIdQuery"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudetDto>
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
        /// Initializes a new instance of the <see cref="GetStudentByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        public GetStudentByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
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
        public async Task<StudetDto> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
        {
            //Get
            var results = await _unitOfWork.Repository<Student>().GetByIdAsync(query.Id);
            await _unitOfWork.SaveAsync(cancellationToken);
            //Return
            return _mapper.Map<StudetDto>(results);
        }

        #endregion Public Methods
    }
}