using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.WorkSchedules.Queries.GetAll;

public sealed class GetAllWorkScheduleQueryHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
    : IRequestHandler<GetAllWorkScheduleQuery, Result<IQueryable<GetAllWorkScheduleResponse>>>
{
    private readonly ICurrentUserService _currentUserService = currentUserService;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<IQueryable<GetAllWorkScheduleResponse>>> Handle(GetAllWorkScheduleQuery request, CancellationToken cancellationToken)
    {
        var clinicId = _currentUserService.GetClinicId();
        var lst = _unitOfWork.WorkScheduleRepository.GetAll()
        .Where(x => x.ClinicId == clinicId)
        .ToDto();

        return Result.Success(lst);
    }
}
