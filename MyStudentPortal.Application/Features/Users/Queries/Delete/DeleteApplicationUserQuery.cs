using AutoMapper;
using MediatR;
using MyStudentPortal.Application.Repositories.Interfaces;
using MyStudentPortal.Domain.Entities;

namespace MyStudentPortal.Application.Features.Users.Queries
{
    public record DeleteApplicationUserQuery : IRequest<bool>
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteApplicationUserQuery"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public DeleteApplicationUserQuery(int id)
        {
            Id = id;
        }
    }

    public class DeleteApplicationUserQueryHandler : IRequestHandler<DeleteApplicationUserQuery, bool>
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
        /// Initializes a new instance of the <see cref="DeleteApplicationUserQueryHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        public DeleteApplicationUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
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
        public async Task<bool> Handle(DeleteApplicationUserQuery query, CancellationToken cancellationToken)
        {
            //Get user
            var user = await _unitOfWork.Repository<ApplicationUser>().GetByIdAsync(query.Id);

            //Delete
            if (user == null)
                return false;

            await _unitOfWork.Repository<ApplicationUser>().DeleteAsync(user);

            await _unitOfWork.SaveAsync(cancellationToken);

            //Return
            return true;
        }

        #endregion Public Methods
    }
}