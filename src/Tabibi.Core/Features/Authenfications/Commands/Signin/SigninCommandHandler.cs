using MediatR;
using Reygency.Infrastructure.Features.Authenifactions;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Authenfications.Commands.Signin
{
    public sealed class SigninCommandHandler(IAuthenficationsServices authenficationsServices) : IRequestHandler<SigninCommand, Result<string>>
    {
        private readonly IAuthenficationsServices _authenficationsServices = authenficationsServices;

        public async Task<Result<string>> Handle(SigninCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenficationsServices.SigninAsync(request.EmailOrUserName, request.Password);
            return result;
        }
    }
}
