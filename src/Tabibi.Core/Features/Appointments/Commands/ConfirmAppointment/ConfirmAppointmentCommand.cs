using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Appointments.Commands.ConfirmAppointment;

public sealed record ConfirmAppointmentCommand(Guid Id) : IRequest<Result<string>>;
