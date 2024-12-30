using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalFile.BloodPressures.Commands.Add
{
    public sealed record AddBloodPressureCommand(Guid PatientId, decimal MinValue, decimal MaxValue, string? Notes)
        : IRequest<Result<Guid>>;
}
