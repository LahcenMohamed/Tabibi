using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalHistory.ChronicDiseases.Queries.GetByPatientId
{
    public sealed record GetChronicDiseasesByPatientIdQuery(Guid PatientId)
        : IRequest<Result<IQueryable<ChronicDiseasesResponse>>>;
}