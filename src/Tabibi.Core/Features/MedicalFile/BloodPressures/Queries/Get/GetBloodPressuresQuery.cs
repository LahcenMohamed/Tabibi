using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalFile.BloodPressures.Queries.Get
{
    public sealed record GetBloodPressuresQuery(Guid PatientId)
        : IRequest<Result<List<GetBloodPressuresQueryResponse>>>;
}
