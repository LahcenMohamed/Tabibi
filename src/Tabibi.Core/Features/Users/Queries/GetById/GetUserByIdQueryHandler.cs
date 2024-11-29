using MediatR;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.Users;

namespace Tabibi.Core.Features.Users.Queries.GetById
{
    public sealed class GetUserByIdQueryHandler(IUserServices userServices) : IRequestHandler<GetUserByIdQuery, Result<GetUserByIdQueryResult>>
    {
        private readonly IUserServices _userServices = userServices;

        public async Task<Result<GetUserByIdQueryResult>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = _userServices.GetById(request.Id);
            if (user is null)
            {
                return Result.NotFound<GetUserByIdQueryResult>("Id does not exist");
            }
            GetUserByIdQueryMapper mapper = new GetUserByIdQueryMapper();
            var userMapping = mapper.ToGetByIdResult(user);
            return Result.Success(userMapping);
        }
    }
}
