using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabibi.Api.Bases;
using Tabibi.Core.Features.MedicalFile.Temperatures.Commands.Add;
using Tabibi.Core.Features.MedicalFile.Temperatures.Queries;

namespace Tabibi.Api.Controllers.Patients.MedicalFile
{
    [Route("api/patients/temperatures")]
    [ApiController]
    [Authorize(Roles = "Patient")]
    public sealed class TemperatureController : AppControllerBase
    {
        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetTemperatures(Guid patientId)
        {
            var result = await Mediator.Send(new GetTemperaturesQuery(patientId));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddTemperature(AddTemperatureCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
