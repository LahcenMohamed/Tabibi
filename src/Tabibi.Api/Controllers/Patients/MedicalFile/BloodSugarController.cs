using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabibi.Api.Bases;
using Tabibi.Core.Features.MedicalFile.BloodSugars.Commands.Add;
using Tabibi.Core.Features.MedicalFile.BloodSugars.Commands.Delete;
using Tabibi.Core.Features.MedicalFile.BloodSugars.Commands.Update;
using Tabibi.Core.Features.MedicalFile.BloodSugars.Queries;

namespace Tabibi.Api.Controllers.Patients.MedicalFile
{
    [Route("api/patients/blood-sugars")]
    [ApiController]
    [Authorize(Roles = "Patient")]
    public sealed class BloodSugarController : AppControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddBloodSugar(AddBloodSugarCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBloodSugar(UpdateBloodSugarCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBloodSugar(Guid id)
        {
            var result = await Mediator.Send(new DeleteBloodSugarCommand(id));
            return NewResult(result);
        }

        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetBloodSugars(Guid patientId)
        {
            var result = await Mediator.Send(new GetBloodSugarsQuery(patientId));
            return NewResult(result);
        }
    }
}
