using MediatR;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.Users;

namespace Tabibi.Core.Features.Authenfications.Commands.SendResetPasswordToken
{
    public sealed class SendResetPasswordTokenCommandHandler(IUserServices userServices)
        : IRequestHandler<SendResetPasswordTokenCommand, Result<string>>
    {
        private readonly IUserServices _userServices = userServices;

        public async Task<Result<string>> Handle(SendResetPasswordTokenCommand request, CancellationToken cancellationToken)
        {
            var result = await _userServices.SendForgetPasswordCodeAsync(request.UserNameOrEmail);
            return result;
        }
    }
}
