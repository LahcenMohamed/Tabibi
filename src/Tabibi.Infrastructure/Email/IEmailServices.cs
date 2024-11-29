using Tabibi.Domain.Shared.Results;

namespace Tabibi.Infrastructure.Email
{
    public interface IEmailServices
    {
        public Task<Result<string>> SendEmailAsync(string email, string Message, string? reason);
    }
}
