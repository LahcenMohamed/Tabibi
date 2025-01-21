using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabibi.Api.Bases;
using Tabibi.Core.Features.MedicalFile.BloodPressures.Commands.Add;
using Tabibi.Core.Features.MedicalFile.BloodPressures.Queries.Get;

namespace Tabibi.Api.Controllers.Patients.MedicalFile
{
    [Route("api/patients/blood-pressures")]
    [ApiController]
    [Authorize(Roles = "Patient")]
    public sealed class BloodPressureController : AppControllerBase
    {
        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetBloodPressures(Guid patientId)
        {
            var result = await Mediator.Send(new GetBloodPressuresQuery(patientId));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddBloodPressure(AddBloodPressureCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
