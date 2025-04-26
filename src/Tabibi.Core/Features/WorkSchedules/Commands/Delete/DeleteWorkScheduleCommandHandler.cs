using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.WorkSchedules.Commands.Delete;

public sealed class DeleteWorkScheduleCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteWorkScheduleCommand, Result<string>>
{
    private readonly ICurrentUserService _currentUserService = currentUserService;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<string>> Handle(DeleteWorkScheduleCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.GetUserId();
        var clinicId = _currentUserService.GetClinicId();
        var workSchedule = _unitOfWork.WorkScheduleRepository.GetById(request.Id);
        if(workSchedule is null || workSchedule.ClinicId != clinicId)
        {
            return Result.NotFound();            
        }
        _unitOfWork.WorkScheduleRepository.Delete(workSchedule, userId);
        await _unitOfWork.SaveChangesAsync();
        return Result.Success("");
    }
}