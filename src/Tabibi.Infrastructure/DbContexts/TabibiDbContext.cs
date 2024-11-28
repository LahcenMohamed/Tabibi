using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tabibi.Domain.Doctors;
using Tabibi.Domain.Users;

namespace Tabibi.Infrastructure.DbContexts
{
    public sealed class TabibiDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<Doctor> Doctors { get; private set; }
        public TabibiDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(TabibiDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
