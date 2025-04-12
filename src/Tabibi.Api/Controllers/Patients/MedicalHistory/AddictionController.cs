using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabibi.Api.Bases;
using Tabibi.Core.Features.MedicalHistory.Addictions.Commands.Add;
using Tabibi.Core.Features.MedicalHistory.Addictions.Commands.Delete;
using Tabibi.Core.Features.MedicalHistory.Addictions.Commands.Update;
using Tabibi.Core.Features.MedicalHistory.Addictions.Queries.GetByPatientId;

namespace Tabibi.Api.Controllers.Patients.MedicalHistory
{
    [Route("api/patients/medical-history/addictions")]
    [ApiController]
    [Authorize(Roles = "Patient")]
    public class AddictionController : AppControllerBase
    {
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteAddictionCommand(id);
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAddictionCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAddictionCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetByPatientId([FromRoute] Guid patientId)
        {
            var query = new GetAddictionsByPatientIdQuery(patientId);
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
    }
}