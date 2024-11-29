using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Authenfications.Commands.SendResetPasswordToken
{
    public sealed record SendResetPasswordTokenCommand(string UserNameOrEmail) : IRequest<Result<string>>;
}
