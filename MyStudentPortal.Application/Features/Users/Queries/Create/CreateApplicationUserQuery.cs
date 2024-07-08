using AutoMapper;
using MediatR;
using MyStudentPortal.Application.Common;
using MyStudentPortal.Application.Repositories.Interfaces;
using MyStudentPortal.Domain.Entities;

namespace MyStudentPortal.Application.Features.Users.Queries
{
    public record CreateApplicationUserQuery : IRequest<ApplicationUserDto>
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

    public class CreateApplicationUserQueryHandler : IRequestHandler<CreateApplicationUserQuery, ApplicationUserDto>
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
        public CreateApplicationUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
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
        public async Task<ApplicationUserDto> Handle(CreateApplicationUserQuery query, CancellationToken cancellationToken)
        {
            //Map
            var newUser = _mapper.Map<ApplicationUser>(query.ApplicationUserDto);
            //Encrypt password
            newUser.PasswordHash = PasswordEncryption.EncryptPassword(query.ApplicationUserDto.Password);
            //SaveAsync

            var results = await _unitOfWork.Repository<ApplicationUser>().AddAsync(newUser);

            await _unitOfWork.SaveAsync(cancellationToken);

            //Return
            return _mapper.Map<ApplicationUserDto>(results);
        }

        #endregion Public Methods
    }
}