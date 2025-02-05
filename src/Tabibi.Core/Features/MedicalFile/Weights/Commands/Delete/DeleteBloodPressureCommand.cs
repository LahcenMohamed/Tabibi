using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalFile.Weights.Commands.Delete
{
    public sealed record DeleteWeightCommand(Guid Id) : IRequest<Result<string>>;
}
