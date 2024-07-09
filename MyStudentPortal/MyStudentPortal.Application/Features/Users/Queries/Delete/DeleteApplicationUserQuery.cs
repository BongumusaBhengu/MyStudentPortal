using MediatR;
using MyStudentPortal.Application.Repositories.Interfaces;

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
        /// The application user repository
        /// </summary>
        private readonly IApplicationUserRepository _applicationUserRepository;

        #endregion Private Fields

        #region Public Constructors


        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteApplicationUserQueryHandler"/> class.
        /// </summary>
        /// <param name="applicationUserRepository">The application user repository.</param>
        public DeleteApplicationUserQueryHandler(IApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
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
            return await _applicationUserRepository.DeleteByIdAsync(query.Id);
        }

        #endregion Public Methods
    }
}