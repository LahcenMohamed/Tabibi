using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalHistory.Allergies.Queries.GetByPatientId
{
    public sealed record GetAllergiesByPatientIdQuery(Guid PatientId) : IRequest<Result<IQueryable<AllergyDto>>>;
}