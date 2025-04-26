using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabibi.Domain.Patients;
using Tabibi.Domain.WorkSchedules;
using Tabibi.Domain.WorkSchedules.Entities.Appointments;

namespace Tabibi.Infrastructure.Configurations
{
    public sealed class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);
            builder.HasOne<WorkSchedule>()
            .WithMany()
            .HasForeignKey(x => x.WorkScheduleId);

            builder.HasOne<Patient>()
            .WithMany()
            .HasForeignKey(x => x.PatientId);
        }
    }
}