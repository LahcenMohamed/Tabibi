using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.Appointments.Commands.Update;

public sealed class UpdateAppointmentCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    : IRequestHandler<UpdateAppointmentCommand, Result<string>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ICurrentUserService _currentUserService = currentUserService;

    public async Task<Result<string>> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.GetUserId();
        var appointment = _unitOfWork.AppointmentRepository.GetById(request.Id);
        if(appointment is null)
        {
            return Result.NotFound();
        }
        appointment.Update(request.Number, request.WorkScheduleId, userId);
        _unitOfWork.AppointmentRepository.Update(appointment);
        await _unitOfWork.SaveChangesAsync();
        return Result.Success("");
    }
}
