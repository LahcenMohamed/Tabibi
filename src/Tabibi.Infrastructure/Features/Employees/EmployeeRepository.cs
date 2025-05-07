using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Npgsql;
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
                        public.""Employees"".""Id"",
                        public.""Employees"".""FullName_FirstName"" AS FirstName,
                        public.""Employees"".""FullName_MiddelName"" AS MiddelName,
                        public.""Employees"".""FullName_LastName"" AS LastName,
                        public.""Employees"".""PhoneNumber"",
                        public.""Employees"".""Email"",
                        public.""Employees"".""Address"",
                        public.""Employees"".""Salary"",
                        public.""Employees"".""JobType"",
                        public.""Employees"".""Description"",
                        public.""Employees"".""IsDeleted"",
                        public.""Employees"".""ClinicId""
                    FROM public.""Employees""
                    WHERE public.""Employees"".""ClinicId"" = @clinicId
                    AND public.""Employees"".""IsDeleted"" = false";


            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            var lst = connection.Query<TResponse>(sql, new { clinicId }).AsQueryable();
            return lst;
        }
    }
}
