using Tabibi.Domain.Users;

namespace Tabibi.Infrastructure.Features.CurrentUser
{
    public interface ICurrentUserService
    {
        public Task<ApplicationUser> GetUserAsync();
        public Guid GetUserId();
        public Guid GetClinicId();
        public Task<List<string>> GetCurrentUserRolesAsync();
    }
}
