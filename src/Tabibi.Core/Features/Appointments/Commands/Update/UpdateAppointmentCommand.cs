using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Appointments.Commands.Update;

public sealed record UpdateAppointmentCommand(Guid Id, int Number, Guid WorkScheduleId) 
    : IRequest<Result<string>>;
