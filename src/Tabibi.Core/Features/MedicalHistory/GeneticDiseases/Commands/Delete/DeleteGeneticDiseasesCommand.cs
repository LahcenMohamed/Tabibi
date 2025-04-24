using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalHistory.GeneticDiseases.Commands.Delete
{
    public sealed record DeleteGeneticDiseasesCommand(Guid Id) : IRequest<Result<string>>;
}
