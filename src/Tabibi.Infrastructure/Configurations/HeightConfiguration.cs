using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabibi.Domain.Patients;
using Tabibi.Domain.Patients.Entities;

namespace Tabibi.Infrastructure.Configurations
{
    public sealed class HeightConfiguration : IEntityTypeConfiguration<Height>
    {
        public void Configure(EntityTypeBuilder<Height> builder)
        {
            builder.HasOne<Patient>()
                   .WithMany()
                   .HasForeignKey(x => x.PatientId);
        }
    }
}
