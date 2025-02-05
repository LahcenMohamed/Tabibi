using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalFile.Weights.Commands.Update
{
    public sealed record UpdateWeightCommand(Guid Id, decimal Value, string? Notes)
        : IRequest<Result<string>>;
}
