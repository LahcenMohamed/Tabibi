using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Tabibi.Domain.Clinics.Entities.JobTimes;
using Tabibi.Infrastructure.DbContexts;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.JobTimes
{
    public sealed class JobTimeRepository(TabibiDbContext context, IConfiguration configuration)
        : BaseRepository<JobTime>(context, configuration), IJobTimeRepository
    {
        public IQueryable<TResponse> GetByClinicId<TResponse>(Guid clinicId)
        {
            string sql = @"SELECT 
                            Id,
                            Day,
                            StartTime,
                            EndTime,
                            IsDeleted,
                            ClinicId
                           FROM JobTimes
                           WHERE IsDeleted = 0
                           AND ClinicId = @clinicId";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var clinics = connection.Query<TResponse>(sql, new { clinicId }).AsQueryable();
            return clinics;

        }
    }
}
