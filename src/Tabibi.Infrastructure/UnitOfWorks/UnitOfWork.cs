using Microsoft.Extensions.Configuration;
using Tabibi.Infrastructure.DbContexts;
using Tabibi.Infrastructure.Features.Clinics;
using Tabibi.Infrastructure.Features.Doctors;
using Tabibi.Infrastructure.Features.Employees;
using Tabibi.Infrastructure.Features.JobTimes;

namespace Reygency.Infrastructure.UnitOfWorks
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        public IClinicRepository ClinicRepository { get; }
        public IDoctorRepository DoctorRepository { get; }
        public IJobTimeRepository JobTimeRepository { get; }
        public IEmployeeRepository EmployeeRepository { get; }

        private readonly TabibiDbContext _context;
        private readonly IConfiguration _configuration;

        public UnitOfWork(TabibiDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            ClinicRepository = new ClinicRepository(context, _configuration);
            DoctorRepository = new DoctorRepository(context, _configuration);
            JobTimeRepository = new JobTimeRepository(context, _configuration);
            EmployeeRepository = new EmployeeRepository(context, configuration);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
