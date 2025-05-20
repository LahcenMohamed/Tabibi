using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabibi.Api.Bases;
using Tabibi.Core.Features.MedicalHistory.ChronicDiseases.Commands.Add;
using Tabibi.Core.Features.MedicalHistory.ChronicDiseases.Commands.Delete;
using Tabibi.Core.Features.MedicalHistory.ChronicDiseases.Commands.Update;
using Tabibi.Core.Features.MedicalHistory.ChronicDiseases.Queries.GetByPatientId;

namespace Tabibi.Api.Controllers.Patients.MedicalHistory
{
    [Route("api/patients/medical-history/chronic-diseases")]
    [ApiController]
    [Authorize]
    public class ChronicDiseasesController : AppControllerBase
    {

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return NewResult(await Mediator.Send(new DeleteChronicDiseaseCommand(id)));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateChronicDiseaseCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<IActionResult> Update(AddChronicDiseasesCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }

        [HttpGet("patient/{patientId}")]
         [AllowAnonymous]
        public async Task<IActionResult> GetByPatientId(Guid patientId)
        {
            return NewResult(await Mediator.Send(new GetChronicDiseasesByPatientIdQuery(patientId)));
        }
    }
}