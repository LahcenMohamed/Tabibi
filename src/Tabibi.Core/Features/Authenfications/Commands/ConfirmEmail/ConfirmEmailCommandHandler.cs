using MediatR;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.Users;

namespace Tabibi.Core.Features.Authenfications.Commands.ConfirmEmail
{
    public sealed class ConfirmEmailCommandHandler(IUserServices userServices) : IRequestHandler<ConfirmEmailCommand, Result<string>>
    {
        private readonly IUserServices _userServices = userServices;

        public async Task<Result<string>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var result = await _userServices.ConfirmEmailAsync(request.UserNameOrEmail, request.Code);
            return result;
        }
    }
}
