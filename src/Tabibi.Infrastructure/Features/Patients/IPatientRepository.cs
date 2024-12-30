using Tabibi.Domain.Patients;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.Patients
{
    public interface IPatientRepository : IBaseRepository<Patient>
    {
    }
}
