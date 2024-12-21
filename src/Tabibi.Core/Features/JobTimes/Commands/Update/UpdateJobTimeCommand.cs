using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.JobTimes.Commands.Update
{
    public sealed record UpdateJobTimeCommand(Guid Id, DayOfWeek Day, TimeOnly StartTime, TimeOnly EndTime) : IRequest<Result<string>>;
}
