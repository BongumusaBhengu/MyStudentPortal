using AutoMapper;
using MediatR;
using MyStudentPortal.Application.Repositories.Interfaces;
using MyStudentPortal.Domain.Entities;

namespace MyStudentPortal.Application.Features.Users.Queries
{
    public record GetUserApplicationUserByIdQuery : IRequest<ApplicationUserDto>
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserApplicationUserByIdQuery"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public GetUserApplicationUserByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetUserApplicationUserByIdQueryHandler : IRequestHandler<GetUserApplicationUserByIdQuery, ApplicationUserDto>
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
        /// Initializes a new instance of the <see cref="GetUserApplicationUserByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        public GetUserApplicationUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
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
        public async Task<ApplicationUserDto> Handle(GetUserApplicationUserByIdQuery query, CancellationToken cancellationToken)
        {
            //Get
            var results = await _unitOfWork.Repository<ApplicationUser>().GetByIdAsync(query.Id);
            await _unitOfWork.SaveAsync(cancellationToken);

            //Return
            return _mapper.Map<ApplicationUserDto>(results);
        }

        #endregion Public Methods
    }
}