using AutoMapper;
using MediatR;
using MyStudentPortal.Application.Repositories.Interfaces;
using MyStudentPortal.Domain.Entities;

namespace MyStudentPortal.Application.Features.Enrollments.Queries.Create
{
    public record CreateEnrollmentsQuery : IRequest
    {
        public EnrollmentsDto EnrollmentsDto { get; set; }
        public CreateEnrollmentsQuery(EnrollmentsDto enrollmentsDto)
        {
            EnrollmentsDto = enrollmentsDto;
        }
    }
    public class CreateEnrollmentsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
       : IRequestHandler<CreateEnrollmentsQuery>
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
        public async Task Handle(CreateEnrollmentsQuery query, CancellationToken cancellationToken)
        {
            //Map
            var enrollment = mapper.Map<Enrollment>(query.EnrollmentsDto);

            await unitOfWork.Repository<Enrollment>().AddAsync(enrollment);

            await unitOfWork.SaveAsync(cancellationToken);
        }

        #endregion Public Methods

    }
}
