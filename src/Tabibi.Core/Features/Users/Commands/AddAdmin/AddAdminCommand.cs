using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Users.Commands.AddAdmin
{
    public sealed record AddAdminCommand(string UserName, string Password, string Email) : IRequest<Result<string>>;
}
