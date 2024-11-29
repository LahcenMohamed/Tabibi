using MediatR;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.Users;

namespace Tabibi.Core.Features.Users.Queries.GetAll
{
    public sealed class GetAllUsersQueryHandler(IUserServices userServices) : IRequestHandler<GetAllUsersQuery, Result<IQueryable<GetAllUsersQueryResult>>>
    {
        private readonly IUserServices _userServices = userServices;

        public async Task<Result<IQueryable<GetAllUsersQueryResult>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _userServices.GetAll().FromUser();
            return Result.Success(users);
        }
    }
}
