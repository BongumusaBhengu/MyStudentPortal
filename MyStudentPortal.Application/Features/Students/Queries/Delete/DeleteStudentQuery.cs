using MediatR;
using MyStudentPortal.Application.Repositories.Interfaces;
using MyStudentPortal.Domain.Entities;

namespace MyStudentPortal.Application.Features.Students.Queries
{
    public record DeleteStudentUserQuery : IRequest<bool>
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteStudentUserQuery"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public DeleteStudentUserQuery(int id)
        {
            Id = id;
        }
    }

    public class DeleteStudentUserQueryHandler : IRequestHandler<DeleteStudentUserQuery, bool>
    {
        #region Private Fields

        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteStudentUserQueryHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        public DeleteStudentUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Handles the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<bool> Handle(DeleteStudentUserQuery query, CancellationToken cancellationToken)
        {
            //Get user
            var user = await _unitOfWork.Repository<Student>().GetByIdAsync(query.Id);

            //Delete
            if (user == null)
                return false;

            await _unitOfWork.Repository<Student>().DeleteAsync(user);
            await _unitOfWork.SaveAsync(cancellationToken);
            //Return
            return true;
        }

        #endregion Public Methods
    }
}