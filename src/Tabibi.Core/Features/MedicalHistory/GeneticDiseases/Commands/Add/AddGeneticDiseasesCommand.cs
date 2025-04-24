using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalHistory.GeneticDiseases.Commands.Add
{
    public sealed record AddGeneticDiseasesCommand(Guid PatientId, string DiseaseName) : IRequest<Result<Guid>>;
}
