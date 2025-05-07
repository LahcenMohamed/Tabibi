using Dapper;
using Npgsql;
using Microsoft.Extensions.Configuration;
using Tabibi.Domain.Clinics.Entities.Doctors;
using Tabibi.Infrastructure.DbContexts;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.Doctors;

public sealed class DoctorRepository(TabibiDbContext context,
                                     IConfiguration configuration)
                                     : BaseRepository<Doctor>(context, configuration), IDoctorRepository
{

    public IQueryable<TResponse> GetAllWithDto<TResponse>()
    {
        string sql = @"SELECT
                    d.""Id"" AS ""Id"",
                    d.""FullName_FirstName"" AS ""FirstName"",
                    d.""FullName_MiddelName"" AS ""MiddelName"",
                    d.""FullName_LastName"" AS ""LastName"",
                    d.""Gender"" AS ""Gender"",
                    d.""DateOfBirth"" AS ""DateOfBirth"",
                    d.""PhoneNumber"" AS ""PhoneNumber"",
                    d.""EmailAddress"" AS ""EmailAddress"",
                    d.""PhotoUrl"" AS ""PhotoUrl"",
                    d.""Notes"" AS ""Notes"",
                    d.""ClinicId"" AS ""ClinicId"",
                    d.""IsDeleted""
                    FROM ""Doctors"" d
                    WHERE d.""IsDeleted"" = false";

        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        var doctors = connection.Query<TResponse>(sql)
            .AsQueryable();

        return doctors;
    }

    public TResponse GetByClinicId<TResponse>(Guid clinicId)
    {
        string sql = @"SELECT
                    d.""Id"" AS ""Id"",
                    d.""FullName_FirstName"" AS ""FirstName"",
                    d.""FullName_MiddelName"" AS ""MiddelName"",
                    d.""FullName_LastName"" AS ""LastName"",
                    d.""Gender"" AS ""Gender"",
                    d.""DateOfBirth"" AS ""DateOfBirth"",
                    d.""PhoneNumber"" AS ""PhoneNumber"",
                    d.""EmailAddress"" AS ""EmailAddress"",
                    d.""PhotoUrl"" AS ""PhotoUrl"",
                    d.""Notes"" AS ""Notes"",
                    d.""ClinicId"" AS ""ClinicId"",
                    d.""IsDeleted""
                    FROM ""Doctors"" d
                    WHERE d.""IsDeleted"" = false
                    AND ""ClinicId"" = @clinicId";

        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        var doctor = connection.QueryFirst<TResponse>(sql, new { clinicId });

        return doctor;
    }
}
