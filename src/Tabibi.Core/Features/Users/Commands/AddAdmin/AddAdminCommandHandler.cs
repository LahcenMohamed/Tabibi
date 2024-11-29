using MediatR;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.Users;

namespace Tabibi.Core.Features.Users.Commands.AddAdmin
{
    public sealed class AddAdminCommandHandler(IUserServices userServices) : IRequestHandler<AddAdminCommand, Result<string>>
    {
        private readonly IUserServices _userServices = userServices;

        public async Task<Result<string>> Handle(AddAdminCommand request, CancellationToken cancellationToken)
        {
            var result = await _userServices.AddAdminAsync(request.UserName, request.Password, request.Email);
            return result;
        }
    }
}
