using Riok.Mapperly.Abstractions;
using Tabibi.Domain.Users;

namespace Tabibi.Core.Features.Users.Queries.GetByPagination
{
    [Mapper]
    public static partial class GetUsersByPaginationQueryMapper
    {
        public static partial IQueryable<GetUsersByPaginationQueryResult> FromUsersToPaginted(this IQueryable<ApplicationUser> users);
    }
}
