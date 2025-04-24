using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalHistory.GeneticDiseases.Commands.Update
{
    public sealed record UpdateGeneticDiseasesCommand(Guid Id, string Name) : IRequest<Result<string>>;
}
