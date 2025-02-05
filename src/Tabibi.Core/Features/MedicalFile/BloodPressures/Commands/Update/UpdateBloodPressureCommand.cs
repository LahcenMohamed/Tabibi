using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalFile.BloodPressures.Commands.Update
{
    public sealed record UpdateBloodPressureCommand(Guid Id, decimal MinValue, decimal MaxValue, string? Notes)
        : IRequest<Result<string>>;
}
