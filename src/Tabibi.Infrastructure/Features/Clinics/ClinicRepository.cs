using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Tabibi.Domain.Clinics;
using Tabibi.Domain.Clinics.Enums;
using Tabibi.Infrastructure.DbContexts;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.Clinics;

public sealed class ClinicRepository(
TabibiDbContext context,
IConfiguration configuration)
: BaseRepository<Clinic>(context, configuration), IClinicRepository
{

    public IQueryable<TResponse> GetAllByDapper<TResponse>(Specialization specialization, string state, string city)
    {
        string sql = @"
                    SELECT 
                        c.Id, 
                        c.Name, 
                        c.MinDescription, 
                        c.Specialization, 
                        c.PhoneNumber, 
                        c.SecondPhoneNumber, 
                        c.Email, 
                        c.Address_State AS State, 
                        c.Address_City AS City, 
                        c.Address_Street AS Street, 
                        c.Address_Note AS Note,
                        c.PhotoUrl, 
                        c.DoctorId, 
                        c.UserId
                    FROM Clinics c
                    WHERE c.Specialization = @specialization 
                    AND c.Address_State LIKE '%' + @state + '%' 
                    AND c.Address_City LIKE '%' + @city + '%'";

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        var clinics = connection.Query<TResponse>(
            sql,
            new { specialization, state, city }
        ).AsQueryable();

        return clinics;
    }

}
