using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalHistory.Addictions.Queries.GetByPatientId
{
    public sealed record GetAddictionsByPatientIdQuery(Guid PatientId) : IRequest<Result<List<AddictionDto>>>;
}