using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalHistory.GeneticDiseases.Queries.GetByPaitentId
{
    public sealed record GetGeneticDiseasesByPatientIdQuery(Guid PatientId)
        : IRequest<Result<IQueryable<GeneticDiseasesResponse>>>;
}
