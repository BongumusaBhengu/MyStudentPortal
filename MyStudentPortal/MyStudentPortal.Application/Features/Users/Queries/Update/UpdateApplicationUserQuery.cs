using AutoMapper;
using MediatR;
using MyStudentPortal.Application.Repositories.Interfaces;
using MyStudentPortal.Domain.Entities;

namespace MyStudentPortal.Application.Features.Users.Queries
{
    public record UpdateApplicationUserQuery : IRequest<ApplicationUserDto>
    {
        /// <summary>
        /// Gets the application user dto.
        /// </summary>
        /// <value>
        /// The application user dto.
        /// </value>
        public ApplicationUserDto ApplicationUserDto { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteApplicationUserQuery"/> class.
        /// </summary>
        /// <param name="applicationUserDto">The application user dto.</param>
        public UpdateApplicationUserQuery(ApplicationUserDto applicationUserDto)
        {
            ApplicationUserDto = applicationUserDto;
        }
    }

    public class UpdateApplicationUserQueryHandler : IRequestHandler<UpdateApplicationUserQuery, ApplicationUserDto>
    {
        #region Private Fields

        private readonly IApplicationUserRepository _applicationUserRepository;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateApplicationUserQueryHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        public UpdateApplicationUserQueryHandler(IApplicationUserRepository applicationUserRepository, IMapper mapper)
        {
            _applicationUserRepository = applicationUserRepository;
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
        public async Task<ApplicationUserDto> Handle(UpdateApplicationUserQuery query, CancellationToken cancellationToken)
        {
            //Map
            var applicationUser = _mapper.Map<ApplicationUser>(query.ApplicationUserDto);
            //Update
            await _applicationUserRepository.UpdateAsync(applicationUser);
            //Return
            return _mapper.Map<ApplicationUserDto>(applicationUser);
        }

        #endregion Public Methods
    }
}