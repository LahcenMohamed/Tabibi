using Microsoft.AspNetCore.Identity;

namespace Tabibi.Domain.Users
{
    public sealed class ApplicationUser : IdentityUser<Guid>
    {
        public string? EmailCode { get; set; }
        public string? ForgetPasswordCode { get; set; }
    }
}
