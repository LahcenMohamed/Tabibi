using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Authenfications.Commands.Signup
{
    public sealed record SignupCommand(string UserName, string Password, string Email) : IRequest<Result<string>>;
}
