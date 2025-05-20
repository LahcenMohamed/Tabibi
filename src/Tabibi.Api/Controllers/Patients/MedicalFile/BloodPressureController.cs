using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabibi.Api.Bases;
using Tabibi.Core.Features.MedicalFile.BloodPressures.Commands.Add;
using Tabibi.Core.Features.MedicalFile.BloodPressures.Commands.Delete;
using Tabibi.Core.Features.MedicalFile.BloodPressures.Commands.Update;
using Tabibi.Core.Features.MedicalFile.BloodPressures.Queries.Get;

namespace Tabibi.Api.Controllers.Patients.MedicalFile
{
    [Route("api/patients/blood-pressures")]
    [ApiController]
    [Authorize(Roles = "Patient")]
    public sealed class BloodPressureController : AppControllerBase
    {
        [HttpGet("{patientId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBloodPressures(Guid patientId)
        {
            var result = await Mediator.Send(new GetBloodPressuresQuery(patientId));
            return NewResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddBloodPressure(AddBloodPressureCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBloodPressure(UpdateBloodPressureCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBloodPressure(Guid id)
        {
            var result = await Mediator.Send(new DeleteBloodPressureCommand(id));
            return NewResult(result);
        }
    }
}
