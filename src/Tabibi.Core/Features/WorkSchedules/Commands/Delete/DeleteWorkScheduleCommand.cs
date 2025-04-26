using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.WorkSchedules.Commands.Delete;

public sealed record DeleteWorkScheduleCommand(Guid Id) : IRequest<Result<string>>;
