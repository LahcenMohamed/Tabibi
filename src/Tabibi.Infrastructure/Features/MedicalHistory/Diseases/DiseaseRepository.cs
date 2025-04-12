using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Tabibi.Domain.Patients.Entities;
using Tabibi.Infrastructure.DbContexts;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.MedicalHistory.Diseases
{
    public sealed class DiseaseRepository(TabibiDbContext context, IConfiguration configuration)
        : BaseRepository<Disease>(context, configuration), IDiseaseRepository
    {
        public IQueryable<TResponse> GetByPatientId<TResponse>(Guid patientId)
        {
            string sql = @"SELECT 
                            Id,
                            Name,
                            StartDate,
                            EndDate
                            CreatedAt,
                            PatientId
                           FROM Diseases
                           WHERE IsDeleted = 0
                           AND PatientId = @patientId";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var lst = connection.Query<TResponse>(sql, new { patientId }).AsQueryable();
            return lst;
        }
    }
}
