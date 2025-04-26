using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Domain.WorkSchedules;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.WorkSchedules.Commands.Add;

public sealed class AddWorkScheduleCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
    : IRequestHandler<AddWorkScheduleCommand, Result<Guid>>
{
    private readonly ICurrentUserService _currentUserService = currentUserService;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<Guid>> Handle(AddWorkScheduleCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.GetUserId();
        var clinicId = _currentUserService.GetClinicId();
        var workSchedule = WorkSchedule.Create(request.Date, request.MaxAppointmentsCount, clinicId, userId);
        _unitOfWork.WorkScheduleRepository.Add(workSchedule);
        await _unitOfWork.SaveChangesAsync();
        return Result.Success(workSchedule.Id);
    }
}
