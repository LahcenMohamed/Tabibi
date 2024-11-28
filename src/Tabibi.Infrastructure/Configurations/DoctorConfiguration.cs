using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabibi.Domain.Doctors;

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

            builder.OwnsOne(x => x.Address, addressBuilder =>
            {
                addressBuilder.Property(x => x.State).IsRequired().HasMaxLength(100);
                addressBuilder.Property(x => x.City).IsRequired().HasMaxLength(100);
            });
        }
    }
}
