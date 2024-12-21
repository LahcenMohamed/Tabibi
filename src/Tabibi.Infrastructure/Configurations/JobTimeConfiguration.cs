using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabibi.Domain.Clinics;
using Tabibi.Domain.Clinics.Entities.JobTimes;

namespace Tabibi.Infrastructure.Configurations
{
    public sealed class JobTimeConfiguration : IEntityTypeConfiguration<JobTime>
    {
        public void Configure(EntityTypeBuilder<JobTime> builder)
        {
            builder.HasOne<Clinic>()
                   .WithMany(x => x.jobTimes)
                   .HasForeignKey(x => x.ClinicId);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
