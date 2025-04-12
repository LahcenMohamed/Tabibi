using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalHistory.Diseases.Queries.GetByPatientId
{
    public sealed record GetDiseasesByPatientIdQuery(Guid PatientId) : IRequest<Result<IQueryable<DiseaseDto>>>;
}