using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabibi.Domain.Patients;
using Tabibi.Domain.Patients.Entities;

namespace Tabibi.Infrastructure.Configurations
{
    public sealed class DiseaseConfiguration : IEntityTypeConfiguration<Disease>
    {
        public void Configure(EntityTypeBuilder<Disease> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.HasOne<Patient>()
                .WithMany()
                .HasForeignKey(x => x.PatientId);
        }
    }

    public sealed class GeneticDiseaseConfiguration : IEntityTypeConfiguration<GeneticDisease>
    {
        public void Configure(EntityTypeBuilder<GeneticDisease> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.HasOne<Patient>()
                .WithMany()
                .HasForeignKey(x => x.PatientId);
        }
    }

    public sealed class ChronicDiseaseConfiguration : IEntityTypeConfiguration<ChronicDisease>
    {
        public void Configure(EntityTypeBuilder<ChronicDisease> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.HasOne<Patient>()
                .WithMany()
                .HasForeignKey(x => x.PatientId);
        }
    }

    public sealed class AllergyConfiguration : IEntityTypeConfiguration<Allergy>
    {
        public void Configure(EntityTypeBuilder<Allergy> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.HasOne<Patient>()
                .WithMany()
                .HasForeignKey(x => x.PatientId);
        }
    }

    public sealed class AddictionConfiguration : IEntityTypeConfiguration<Addiction>
    {
        public void Configure(EntityTypeBuilder<Addiction> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.HasOne<Patient>()
                .WithMany()
                .HasForeignKey(x => x.PatientId);
        }
    }
}
