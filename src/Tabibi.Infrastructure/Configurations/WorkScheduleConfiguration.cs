using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabibi.Domain.Clinics;
using Tabibi.Domain.WorkSchedules;

namespace Tabibi.Infrastructure.Configurations
{
    public sealed class WorkScheduleConfiguration : IEntityTypeConfiguration<WorkSchedule>
    {
        public void Configure(EntityTypeBuilder<WorkSchedule> builder)
        {
            builder.HasOne<Clinic>()
                   .WithMany()
                   .HasForeignKey(x => x.ClinicId);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}