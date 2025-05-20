using Dapper;
using Npgsql;
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
    const string sql = @"
        SELECT
            ""Id"",
            ""MinValue"",
            ""MaxValue"",
            ""Notes"",
            ""IsDeleted"",
            ""CreatedAt"",
            ""PatientId""
        FROM ""BloodPressures""
        WHERE ""IsDeleted"" = FALSE
          AND ""PatientId"" = @patientId";

    using var connection = new NpgsqlConnection(_connectionString);
    connection.Open();
    var result = connection.Query<TResponse>(sql, new { patientId }).AsQueryable();
    return result;
}

    }
}
