using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalFile.Weights.Commands.Add
{
    public sealed record AddWeightCommand(Guid PatientId, decimal Value, string? Notes)
        : IRequest<Result<Guid>>;
}