using Refit;
using Tabibi.Core.Features.Doctors.Commands.Add;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.IntegrationTests.Doctors
{
    public interface IDoctorApi
    {
        [Post("/api/clinic/doctors")]
        Task<ApiResponse<Result<Guid?>>> CreateDoctor(AddDoctorCommand command);
    }
}
