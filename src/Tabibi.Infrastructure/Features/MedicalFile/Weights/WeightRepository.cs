using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Tabibi.Domain.Patients.Entities;
using Tabibi.Infrastructure.DbContexts;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.MedicalFile.Weights
{
    public sealed class WeightRepository(TabibiDbContext context, IConfiguration configuration)
        : BaseRepository<Weight>(context, configuration), IWeightRepository
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
                           FROM Weights
                           WHERE IsDeleted = 0
                           AND PatientId = @patientId";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var weights = connection.Query<TResponse>(sql, new { patientId }).AsQueryable();
            return weights;
        }
    }
}