using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Tabibi.Domain.Patients.Entities;
using Tabibi.Infrastructure.DbContexts;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.MedicalHistory.Addictions
{
    public sealed class AddictionRepository(TabibiDbContext context, IConfiguration configuration)
        : BaseRepository<Addiction>(context, configuration), IAddictionRepository
    {
        public IQueryable<TResponse> GetByPatientId<TResponse>(Guid patientId)
        {
            string sql = @"SELECT 
                            Id,
                            Name,
                            CreatedAt,
                            PatientId
                           FROM Addictions
                           WHERE IsDeleted = 0
                           AND PatientId = @patientId";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var lst = connection.Query<TResponse>(sql, new { patientId }).AsQueryable();
            return lst;
        }
    }
}
