using Riok.Mapperly.Abstractions;
using Tabibi.Domain.Users;

namespace Tabibi.Core.Features.Users.Queries.GetById
{
    [Mapper]
    public partial class GetUserByIdQueryMapper
    {
        public partial GetUserByIdQueryResult ToGetByIdResult(ApplicationUser user);
    }
}
