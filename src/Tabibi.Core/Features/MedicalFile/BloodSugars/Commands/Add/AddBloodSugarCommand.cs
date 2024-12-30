using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalFile.BloodSugars.Commands.Add
{
    public sealed record AddBloodSugarCommand(Guid PatientId, decimal Value, string? Notes)
        : IRequest<Result<Guid>>;
}