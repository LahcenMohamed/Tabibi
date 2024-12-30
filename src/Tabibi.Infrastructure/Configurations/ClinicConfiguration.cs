using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabibi.Domain.Clinics;
using Tabibi.Domain.Users;

namespace Tabibi.Infrastructure.Configurations
{
    public sealed class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.OwnsOne(x => x.Address, addressBuilder =>
            {
                addressBuilder.Property(x => x.State).IsRequired().HasMaxLength(100);
                addressBuilder.Property(x => x.City).IsRequired().HasMaxLength(100);
                addressBuilder.Property(x => x.Street).IsRequired().HasMaxLength(100);
                addressBuilder.Property(x => x.UrlOnMap).HasMaxLength(150);
            });

            builder.HasOne(x => x.Doctor)
                   .WithOne(x => x.Clinic)
                   .HasForeignKey<Clinic>(x => x.DoctorId);

            builder.HasOne<ApplicationUser>()
                   .WithMany()
                   .HasForeignKey(x => x.UserId);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
