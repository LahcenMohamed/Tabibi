using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabibi.Domain.Patients;
using Tabibi.Domain.Patients.Entities;

namespace Tabibi.Infrastructure.Configurations
{
    public sealed class BloodSugarConfiguration : IEntityTypeConfiguration<BloodSugar>
    {
        public void Configure(EntityTypeBuilder<BloodSugar> builder)
        {
            builder.HasOne<Patient>()
                   .WithMany()
                   .HasForeignKey(x => x.PatientId);
        }
    }
}
