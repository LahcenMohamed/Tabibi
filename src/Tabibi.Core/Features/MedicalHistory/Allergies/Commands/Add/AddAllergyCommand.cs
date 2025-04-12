using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalHistory.Allergies.Commands.Add
{
    public sealed record AddAllergyCommand(Guid PatientId, string Name) : IRequest<Result<Guid>>;
}
