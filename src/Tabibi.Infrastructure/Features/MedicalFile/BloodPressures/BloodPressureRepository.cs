using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Tabibi.Domain.Patients.Entities;
using Tabibi.Infrastructure.DbContexts;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.MedicalFile.BloodPressures
{
    public sealed class BloodPressureRepository(TabibiDbContext context, IConfiguration configuration)
        : BaseRepository<BloodPressure>(context, configuration), IBloodPressureRepository
    {
        public IQueryable<TResponse> GetByPatientId<TResponse>(Guid patientId)
        {
            string sql = @"SELECT 
                            Id,
                            MinValue,
                            MaxValue,
                            Notes,
                            IsDeleted,
                            CreatedAt,
                            PatientId
                           FROM BloodPressures
                           WHERE IsDeleted = 0
                           AND PatientId = @patientId";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var bloodPressures = connection.Query<TResponse>(sql, new { patientId }).AsQueryable();
            return bloodPressures;
        }
    }
}
