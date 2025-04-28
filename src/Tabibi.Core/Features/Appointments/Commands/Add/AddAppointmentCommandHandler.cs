using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Domain.WorkSchedules.Entities.Appointments;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.Appointments.Commands.Add;

public sealed class AddAppointmentCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    : IRequestHandler<AddAppointmentCommand, Result<Guid>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ICurrentUserService _currentUserService = currentUserService;

    public async Task<Result<Guid>> Handle(AddAppointmentCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.GetUserId();
        var appointment = Appointment.Create(request.Number, request.PatientId, request.WorkScheduleId, userId);
        _unitOfWork.AppointmentRepository.Add(appointment);
        await _unitOfWork.SaveChangesAsync();
        return Result.Created(appointment.Id);
    }
}
