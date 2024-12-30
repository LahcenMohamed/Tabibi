using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalFile.BloodSugars.Queries
{
    public sealed record GetBloodSugarsQuery(Guid PatientId)
        : IRequest<Result<List<GetBloodSugarsQueryResponse>>>;
}