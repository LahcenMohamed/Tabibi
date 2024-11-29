using MediatR;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.Users;

namespace Tabibi.Core.Features.Authenfications.Commands.ResetPassword
{
    public sealed class ResetPasswordCommandHandler(IUserServices userServices) : IRequestHandler<ResetPasswordCommand, Result<string>>
    {
        private readonly IUserServices _userServices = userServices;

        public async Task<Result<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _userServices.ResetPasswordAsync(request.UserNameOrEmail, request.Code, request.NewPassword);
            return result;
        }
    }
}
