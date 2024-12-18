using Microsoft.Extensions.Configuration;
using Tabibi.Infrastructure.DbContexts;
using Tabibi.Infrastructure.Features.Clinics;
using Tabibi.Infrastructure.Features.Doctors;

namespace Reygency.Infrastructure.UnitOfWorks
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        public IClinicRepository ClinicRepository { get; }
        public IDoctorRepository DoctorRepository { get; }

        private readonly TabibiDbContext _context;
        private readonly IConfiguration _configuration;

        public UnitOfWork(TabibiDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            ClinicRepository = new ClinicRepository(context, _configuration);
            DoctorRepository = new DoctorRepository(context, _configuration);
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
