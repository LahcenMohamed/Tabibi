using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Users.Queries.GetAll
{
    public sealed record GetAllUsersQuery : IRequest<Result<IQueryable<GetAllUsersQueryResult>>>;
}
