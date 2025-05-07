using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.WorkSchedules;

namespace Tabibi.Core.Features.WorkSchedules.Queries.GetByClinic;

public sealed class GetWorkSchedulesByClinicQueryHandler 
    : IRequestHandler<GetWorkSchedulesByClinicQuery, Result<List<GetWorkSchedulesByClinicResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetWorkSchedulesByClinicQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<List<GetWorkSchedulesByClinicResponse>>> Handle(
        GetWorkSchedulesByClinicQuery request, 
        CancellationToken cancellationToken)
    {
        var workSchedules = await _unitOfWork.WorkScheduleRepository.GetByClinicIdAsync(request.ClinicId);
        return Result.Success(GetWorkSchedulesByClinicResponseMapper.ToResponse(workSchedules));
    }
}