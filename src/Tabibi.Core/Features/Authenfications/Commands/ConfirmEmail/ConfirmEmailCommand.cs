using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Authenfications.Commands.ConfirmEmail
{
    public sealed record ConfirmEmailCommand(string UserNameOrEmail, string Code) : IRequest<Result<string>>;
}
