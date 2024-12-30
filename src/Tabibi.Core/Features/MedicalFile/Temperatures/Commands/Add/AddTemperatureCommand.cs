using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalFile.Temperatures.Commands.Add
{
    public sealed record AddTemperatureCommand(Guid PatientId, decimal Value, string? Notes)
        : IRequest<Result<Guid>>;
}