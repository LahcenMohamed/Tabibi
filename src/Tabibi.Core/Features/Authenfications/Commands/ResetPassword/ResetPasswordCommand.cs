using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Authenfications.Commands.ResetPassword
{
    public sealed record ResetPasswordCommand(string UserNameOrEmail,
                                              string Code,
                                              string NewPassword) : IRequest<Result<string>>;
}
