using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabibi.Domain.Clinics.Entities.Doctors;

namespace Tabibi.Infrastructure.Configurations
{
    public sealed class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.OwnsOne(x => x.FullName, fullNameBuilder =>
            {
                fullNameBuilder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
                fullNameBuilder.Property(x => x.MiddelName).HasMaxLength(100);
                fullNameBuilder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            });

            builder.HasOne(x => x.Clinic)
                   .WithOne(x => x.Doctor)
                   .HasForeignKey<Doctor>(x => x.ClinicId);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
