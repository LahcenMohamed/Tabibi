using Microsoft.Extensions.Configuration;
using Tabibi.Domain.Patients;
using Tabibi.Infrastructure.DbContexts;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.Patients
{
    public sealed class PatientRepository(TabibiDbContext context, IConfiguration configuration)
        : BaseRepository<Patient>(context, configuration), IPatientRepository
    {
    }
}
