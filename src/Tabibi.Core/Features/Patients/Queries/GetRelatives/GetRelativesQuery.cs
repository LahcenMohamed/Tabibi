using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Patients.Queries.GetRelatives
{
    public sealed class GetRelativesQuery : IRequest<Result<List<GetRelativesResponse>>>
    {
    }
}