using MediatR;
using Reygency.Infrastructure.Features.Authenifactions;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Authenfications.Commands.Signup
{
    public sealed class SignupCommandHandler(IAuthenficationsServices authenficationsServices)
        : IRequestHandler<SignupCommand, Result<string>>
    {
        private readonly IAuthenficationsServices _authenficationsServices = authenficationsServices;

        public async Task<Result<string>> Handle(SignupCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenficationsServices.SignupAsync(request.UserName, request.Password, request.Email);
            return result;
        }
    }
}
