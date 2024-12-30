using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalFile.Weights.Queries
{
    public sealed record GetWeightsQuery(Guid PatientId)
        : IRequest<Result<List<GetWeightsQueryResponse>>>;
}