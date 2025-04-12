using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalHistory.ChronicDiseases.Commands.Add
{
    public sealed record AddChronicDiseasesCommand(Guid PatientId, string DiseaseName) : IRequest<Result<Guid>>;
}