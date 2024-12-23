using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabibi.Domain.Employees;
using Tabibi.Domain.Employees.Entities.EmployeeJobTimes;

namespace Tabibi.Infrastructure.Configurations
{
    public sealed class EmployeeJobTimeConfiguration : IEntityTypeConfiguration<EmployeeJobTime>
    {
        public void Configure(EntityTypeBuilder<EmployeeJobTime> builder)
        {
            builder.HasOne<Employee>()
                   .WithMany(x => x.JobTimes)
                   .HasForeignKey(x => x.EmployeeId);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
