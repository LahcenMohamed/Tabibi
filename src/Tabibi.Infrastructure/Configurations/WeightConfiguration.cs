using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabibi.Domain.Patients;
using Tabibi.Domain.Patients.Entities;

namespace Tabibi.Infrastructure.Configurations
{
    public sealed class WeightConfiguration : IEntityTypeConfiguration<Weight>
    {
        public void Configure(EntityTypeBuilder<Weight> builder)
        {
            builder.HasOne<Patient>()
                   .WithMany()
                   .HasForeignKey(x => x.PatientId);
        }
    }
}
