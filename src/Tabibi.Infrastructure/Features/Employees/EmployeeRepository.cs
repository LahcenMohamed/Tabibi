using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Tabibi.Domain.Employees;
using Tabibi.Infrastructure.DbContexts;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.Employees
{
    public sealed class EmployeeRepository(TabibiDbContext context, IConfiguration configuration)
        : BaseRepository<Employee>(context, configuration), IEmployeeRepository
    {
        public IQueryable<TResponse> GetByClinicId<TResponse>(Guid clinicId)
        {
            var sql = @"
                        SELECT
                            Id,
                            FullName_FirstName AS FirstName,
                            FullName_MiddelName AS MiddelName,
                            FullName_LastName AS LastName,
                            PhoneNumber,
                            Email,
                            Address,
                            Salary,
                            JobType,
                            Description,
                            IsDeleted,
                            ClinicId
                        FROM Employees
                        WHERE ClinicId = @clinicId
                        AND IsDeleted = 0";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var lst = connection.Query<TResponse>(sql, new { clinicId }).AsQueryable();
            return lst;
        }
    }
}
