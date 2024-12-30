using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalFile.Heights.Queries
{
    public sealed record GetHeightsQuery(Guid PatientId)
        : IRequest<Result<List<GetHeightsQueryResponse>>>;
}