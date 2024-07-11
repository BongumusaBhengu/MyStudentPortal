// Ignore Spelling: Dto

using AutoMapper;
using MediatR;
using MyStudentPortal.Application.Common;
using MyStudentPortal.Application.Repositories.Interfaces;
using MyStudentPortal.Domain.Entities;

namespace MyStudentPortal.Application.Features.Users.Queries
{
    public record CreateApplicationUserQuery : IRequest<ApplicationUser?>
    {
        /// <summary>
        /// Gets the application user dto.
        /// </summary>
        /// <value>
        /// The application user dto.
        /// </value>
        public ApplicationUserDto ApplicationUserDto { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateApplicationUserQuery"/> class.
        /// </summary>
        /// <param name="applicationUserDto">The application user dto.</param>
        public CreateApplicationUserQuery(ApplicationUserDto applicationUserDto)
        {
            ApplicationUserDto = applicationUserDto;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateApplicationUserQueryHandler"/> class.
    /// </summary>
    /// <param name="applicationUserRepository">The application user repository.</param>
    /// <param name="mapper">The mapper.</param>
    /// <param name="unitOfWork">
    /// The unit of work
    /// </param>
    public class CreateApplicationUserQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IApplicationUserRepository applicationUserRepository) 
        : IRequestHandler<CreateApplicationUserQuery, ApplicationUser?>
    {

        #region Public Constructors

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Handles the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<ApplicationUser?> Handle(CreateApplicationUserQuery query, CancellationToken cancellationToken)
        {
            //Map
            var newUser = mapper.Map<ApplicationUser>(query.ApplicationUserDto);
            //Encrypt password
            newUser.PasswordHash = PasswordEncryption.EncryptPassword(query.ApplicationUserDto.Password);

            var applicationUser = await applicationUserRepository.CreateAsync(newUser);
            await unitOfWork.SaveAsync(cancellationToken);

            return applicationUser;
        }

        #endregion Public Methods

    }
}