using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Tabibi.Domain.Patients.Entities;
using Tabibi.Infrastructure.DbContexts;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.MedicalFile.Temperatures
{
    public sealed class TemperatureRepository(TabibiDbContext context, IConfiguration configuration)
        : BaseRepository<Temperature>(context, configuration), ITemperatureRepository
    {
        public IQueryable<TResponse> GetByPatientId<TResponse>(Guid patientId)
{
    string sql = @"SELECT 
                    ""Id"",
                    ""Value"",
                    ""Notes"",
                    ""IsDeleted"",
                    ""CreatedAt"",
                    ""PatientId""
                   FROM ""Temperatures""
                   WHERE ""IsDeleted"" = FALSE
                   AND ""PatientId"" = @patientId";

    using var connection = new NpgsqlConnection(_connectionString);
    connection.Open();
    var temperatures = connection.Query<TResponse>(sql, new { patientId }).AsQueryable();
    return temperatures;
}
    }
}