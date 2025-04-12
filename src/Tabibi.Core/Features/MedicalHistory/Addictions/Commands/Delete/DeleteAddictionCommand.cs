using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalHistory.Addictions.Commands.Delete
{
    public sealed record DeleteAddictionCommand(Guid Id) : IRequest<Result<string>>;
}