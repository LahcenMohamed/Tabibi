using Tabibi.Infrastructure.Features.Clinics;
using Tabibi.Infrastructure.Features.Doctors;
using Tabibi.Infrastructure.Features.JobTimes;

namespace Reygency.Infrastructure.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        public IClinicRepository ClinicRepository { get; }
        public IDoctorRepository DoctorRepository { get; }
        public IJobTimeRepository JobTimeRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
