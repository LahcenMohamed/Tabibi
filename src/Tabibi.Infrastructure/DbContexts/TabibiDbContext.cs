using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tabibi.Domain.Clinics;
using Tabibi.Domain.Clinics.Entities.Doctors;
using Tabibi.Domain.Clinics.Entities.JobTimes;
using Tabibi.Domain.Employees;
using Tabibi.Domain.Employees.Entities.EmployeeJobTimes;
using Tabibi.Domain.Users;

namespace Tabibi.Infrastructure.DbContexts
{
    public class TabibiDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<JobTime> JobTimes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeJobTime> EmployeeJobTimes { get; set; }
        public TabibiDbContext()
        {

        }

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
