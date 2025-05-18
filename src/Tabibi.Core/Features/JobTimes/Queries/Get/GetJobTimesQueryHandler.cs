using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.JobTimes.Queries.Get
{
    public sealed class GetJobTimesQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        : IRequestHandler<GetJobTimesQuery, Result<IQueryable<JobTimeResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<Result<IQueryable<JobTimeResponse>>> Handle(GetJobTimesQuery request, CancellationToken cancellationToken)
        {
            var clinicId = _currentUserService.GetClinicId();
            var userId = _currentUserService.GetUserId();

            var lst = _unitOfWork.JobTimeRepository.GetAll().Where(x => x.ClinicId == clinicId).ToDto();

            return Result.Success(lst);
        }
    }
}
