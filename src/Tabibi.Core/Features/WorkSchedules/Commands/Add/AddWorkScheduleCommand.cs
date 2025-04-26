using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.WorkSchedules.Commands.Add;

public sealed record AddWorkScheduleCommand(DateOnly Date, int MaxAppointmentsCount) : IRequest<Result<Guid>>;
