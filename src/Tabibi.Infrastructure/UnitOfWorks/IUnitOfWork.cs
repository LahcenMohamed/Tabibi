using Tabibi.Infrastructure.Features.Clinics;
using Tabibi.Infrastructure.Features.Doctors;

namespace Reygency.Infrastructure.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        public IClinicRepository ClinicRepository { get; }
        public IDoctorRepository DoctorRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
