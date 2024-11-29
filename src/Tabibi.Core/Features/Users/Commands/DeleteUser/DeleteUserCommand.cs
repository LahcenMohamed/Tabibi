using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Users.Commands.DeleteUser
{
    public sealed record DeleteUserCommand(Guid Id) : IRequest<Result<string>>;
}
