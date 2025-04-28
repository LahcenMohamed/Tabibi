using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Appointments.Commands.Add;

public sealed record AddAppointmentCommand(int Number, Guid PatientId, Guid WorkScheduleId)
    : IRequest<Result<Guid>>;
