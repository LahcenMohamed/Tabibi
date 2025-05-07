using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Tabibi.Domain.Patients;
using Tabibi.Infrastructure.DbContexts;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.Patients
{
    public sealed class PatientRepository(TabibiDbContext context, IConfiguration configuration)
        : BaseRepository<Patient>(context, configuration), IPatientRepository
    {
        public async Task<Patient?> GetOwnerByUserIdAsync(Guid userId)
        {
            return await context.Set<Patient>()
                .FirstOrDefaultAsync(p => p.UserId == userId && p.IsOwner);
        }
    }
}
