using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.JobTimes.Commands.Add
{
    public sealed record AddJobTimeCommand(DayOfWeek Day, TimeOnly StartTime, TimeOnly EndTime) : IRequest<Result<Guid>>;
}
