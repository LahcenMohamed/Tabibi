using Tabibi.Domain.Shared.Results;
using Tabibi.Domain.Users;

namespace Tabibi.Infrastructure.Features.Users
{
    public interface IUserServices
    {
        bool IsUserNameExist(string userName);
        bool IsIdExist(Guid Id);
        IQueryable<ApplicationUser> GetAll();
        (IQueryable<ApplicationUser>, int) GetByPaginaion(int pageNumber, int pageSize, string? search);
        ApplicationUser? GetById(Guid id);
        Task<Result<string>> DeleteAsync(Guid Id);
        Task<Result<string>> ConfirmEmailAsync(string userNameOrEmail, string code);
        Task<Result<string>> SendForgetPasswordCodeAsync(string userNameOrEmail);
        Task<Result<string>> ResetPasswordAsync(string userNameOrEmail, string code, string newPassword);
        Task<Result<string>> AddAdminAsync(string userName, string password, string email);
    }
}
