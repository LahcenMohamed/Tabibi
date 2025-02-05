using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabibi.Api.Bases;
using Tabibi.Core.Features.MedicalFile.Temperatures.Commands.Add;
using Tabibi.Core.Features.MedicalFile.Temperatures.Commands.Delete;
using Tabibi.Core.Features.MedicalFile.Temperatures.Commands.Update;
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
            return NewResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddTemperature(AddTemperatureCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTemperature(UpdateTemperatureCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTemperature(Guid id)
        {
            var result = await Mediator.Send(new DeleteTemperatureCommand(id));
            return NewResult(result);
        }
    }
}
