using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Authenfications.Commands.Signin
{
    public sealed record SigninCommand(string EmailOrUserName, string Password) : IRequest<Result<string>>
    {

    }
}
