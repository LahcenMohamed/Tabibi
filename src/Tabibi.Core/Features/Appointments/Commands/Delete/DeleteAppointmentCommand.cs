using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Appointments.Commands.Delete;

public sealed record DeleteAppointmentCommand(Guid Id) : IRequest<Result<string>>;