using Riok.Mapperly.Abstractions;
using Tabibi.Domain.Users;

namespace Tabibi.Core.Features.Users.Queries.GetAll
{
    [Mapper]
    public static partial class GetAllUsersQueryMapper
    {
        public static partial IQueryable<GetAllUsersQueryResult> FromUser(this IQueryable<ApplicationUser> users);
    }
}
