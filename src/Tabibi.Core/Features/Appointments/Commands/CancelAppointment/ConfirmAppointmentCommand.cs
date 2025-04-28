using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Appointments.Commands.CancelAppointment;

public sealed record CancelAppointmentCommand(Guid Id) : IRequest<Result<string>>;
