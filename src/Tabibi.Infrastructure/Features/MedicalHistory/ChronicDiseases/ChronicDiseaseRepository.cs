using Dapper;
using Npgsql;
using Microsoft.Extensions.Configuration;
using Tabibi.Domain.Patients.Entities;
using Tabibi.Infrastructure.DbContexts;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.MedicalHistory.ChronicDiseases
{
    public sealed class ChronicDiseaseRepository(TabibiDbContext context, IConfiguration configuration)
        : BaseRepository<ChronicDisease>(context, configuration), IChronicDiseaseRepository
    {
        public IQueryable<TResponse> GetByPatientId<TResponse>(Guid patientId)
        {
            string sql = @"SELECT
                             ""Id"",
                             ""Name"",
                             ""CreatedAt"",
                             ""PatientId""
                            FROM ""ChronicDiseases""
                            WHERE ""IsDeleted"" = false
                            AND ""PatientId"" = @patientId";
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            var lst = connection.Query<TResponse>(sql, new { patientId }).AsQueryable();
            return lst;
        }
    }
}
