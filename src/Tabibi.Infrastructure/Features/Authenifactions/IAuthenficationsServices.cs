using Tabibi.Domain.Shared.Results;

namespace Reygency.Infrastructure.Features.Authenifactions
{
    public interface IAuthenficationsServices
    {
        Task<Result<string>> SigninAsync(string userNameOrEmail, string password);
        Task<Result<string>> SignupAsync(string userName, string password, string email);
    }
}
