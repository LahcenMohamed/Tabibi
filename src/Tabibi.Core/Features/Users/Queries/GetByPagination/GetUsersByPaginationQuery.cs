using MediatR;
using Tabibi.Core.Wrapper;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Users.Queries.GetByPagination
{
    public sealed class GetUsersByPaginationQuery : PaginatedResquestBase, IRequest<Result<PaginatedResult<GetUsersByPaginationQueryResult>>>
    {
    }
}
