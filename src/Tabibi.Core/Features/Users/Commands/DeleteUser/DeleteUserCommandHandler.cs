using MediatR;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.Users;

namespace Tabibi.Core.Features.Users.Commands.DeleteUser
{
    public sealed class DeleteUserCommandHandler(IUserServices userServices) : IRequestHandler<DeleteUserCommand, Result<string>>
    {
        private readonly IUserServices _userServices = userServices;

        public async Task<Result<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userServices.DeleteAsync(request.Id);
            return result;
        }
    }
}
