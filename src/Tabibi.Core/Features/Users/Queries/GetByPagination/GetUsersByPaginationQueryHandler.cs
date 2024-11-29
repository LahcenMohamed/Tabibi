using MediatR;
using Tabibi.Core.Wrapper;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.Users;

namespace Tabibi.Core.Features.Users.Queries.GetByPagination
{
    public sealed class GetUsersByPaginationQueryHandler(IUserServices userServices) : IRequestHandler<GetUsersByPaginationQuery, Result<PaginatedResult<GetUsersByPaginationQueryResult>>>
    {
        private readonly IUserServices _userServices = userServices;

        public async Task<Result<PaginatedResult<GetUsersByPaginationQueryResult>>> Handle(GetUsersByPaginationQuery request, CancellationToken cancellationToken)
        {
            (var users, int count) = _userServices.GetByPaginaion(request.PageNumber, request.PageSize, request.Search);
            var usersMapping = users.FromUsersToPaginted();
            var result = new PaginatedResult<GetUsersByPaginationQueryResult>(usersMapping, count, request.PageNumber, request.PageSize);
            return Result.Success(result);
        }
    }
}
