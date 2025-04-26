using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.WorkSchedules.Commands.Update;

public sealed record UpdateWorkScheduleCommand(Guid Id, DateOnly Date, int MaxAppointmentsCount)
    : IRequest<Result<string>>;
