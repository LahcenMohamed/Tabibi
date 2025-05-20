using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabibi.Api.Bases;
using Tabibi.Core.Features.MedicalHistory.Diseases.Commands.Add;
using Tabibi.Core.Features.MedicalHistory.Diseases.Commands.Delete;
using Tabibi.Core.Features.MedicalHistory.Diseases.Commands.Update;
using Tabibi.Core.Features.MedicalHistory.Diseases.Queries.GetByPatientId;

namespace Tabibi.Api.Controllers.Patients.MedicalHistory
{
    [Route("api/patients/medical-history/diseases")]
    [ApiController]
    [Authorize]
    public class DiseasesController : AppControllerBase
    {

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return NewResult(await Mediator.Send(new DeleteDiseaseCommand(id)));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateDiseaseCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<IActionResult> Update(AddDiseaseCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }

        [HttpGet("patient/{patientId}")]
         [AllowAnonymous]
        public async Task<IActionResult> GetByPatientId(Guid patientId)
        {
            return NewResult(await Mediator.Send(new GetDiseasesByPatientIdQuery(patientId)));
        }
    }
}