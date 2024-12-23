using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabibi.Domain.Clinics;
using Tabibi.Domain.Employees;

namespace Tabibi.Infrastructure.Configurations
{
    public sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.OwnsOne(x => x.FullName, fullNameBuilder =>
            {
                fullNameBuilder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
                fullNameBuilder.Property(x => x.MiddelName).HasMaxLength(100);
                fullNameBuilder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            });

            builder.Property(x => x.Address).HasMaxLength(200);
            builder.Property(x => x.PhoneNumber).HasMaxLength(20);

            builder.HasOne<Clinic>()
                   .WithMany()
                   .HasForeignKey(x => x.ClinicId);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
