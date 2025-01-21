using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Tabibi.Domain.Patients.Entities;
using Tabibi.Infrastructure.DbContexts;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.MedicalFile.BloodSugars
{
    public sealed class BloodSugarRepository(TabibiDbContext context, IConfiguration configuration)
        : BaseRepository<BloodSugar>(context, configuration), IBloodSugarRepository
    {
        public IQueryable<TResponse> GetByPatientId<TResponse>(Guid patientId)
        {
            string sql = @"SELECT 
                            Id,
                            Value,
                            Notes,
                            IsDeleted,
                            CreatedAt,
                            PatientId
                           FROM BloodSugars
                           WHERE IsDeleted = 0
                           AND PatientId = @patientId";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var bloodSugars = connection.Query<TResponse>(sql, new { patientId }).AsQueryable();
            return bloodSugars;
        }
    }
}