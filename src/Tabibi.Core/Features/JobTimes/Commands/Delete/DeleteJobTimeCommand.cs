using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.JobTimes.Commands.Delete
{
    public sealed record DeleteJobTimeCommand(Guid Id) : IRequest<Result<object>>;
}
