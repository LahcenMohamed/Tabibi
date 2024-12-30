using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Tabibi.Domain.Patients.Entities;
using Tabibi.Infrastructure.DbContexts;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.MedicalFile.Heights
{
    public sealed class HeightRepository(TabibiDbContext context, IConfiguration configuration)
        : BaseRepository<Height>(context, configuration), IHeightRepository
    {
        public IQueryable<TResponse> GetByPatientId<TResponse>(Guid patientId)
        {
            string sql = @"SELECT 
                            Id,
                            Value,
                            Notes,
                            IsDeleted,
                            LastModifiedAt,
                            PatientId
                           FROM Heights
                           WHERE IsDeleted = 0
                           AND PatientId = @patientId";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var heights = connection.Query<TResponse>(sql, new { patientId }).AsQueryable();
            return heights;
        }
    }
}