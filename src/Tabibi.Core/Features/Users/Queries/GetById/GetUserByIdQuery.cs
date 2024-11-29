using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Users.Queries.GetById
{
    public sealed record GetUserByIdQuery(Guid Id) : IRequest<Result<GetUserByIdQueryResult>>;
}
