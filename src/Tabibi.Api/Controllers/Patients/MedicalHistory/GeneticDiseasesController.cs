using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabibi.Api.Bases;
using Tabibi.Core.Features.MedicalHistory.GeneticDiseases.Commands.Add;
using Tabibi.Core.Features.MedicalHistory.GeneticDiseases.Commands.Delete;
using Tabibi.Core.Features.MedicalHistory.GeneticDiseases.Commands.Update;
using Tabibi.Core.Features.MedicalHistory.GeneticDiseases.Queries.GetByPaitentId;

namespace Tabibi.Api.Controllers.Patients.MedicalHistory
{
    [Route("api/patients/medical-history/genetic-diseases")]
    [ApiController]
    [Authorize(Roles = "Patient")]
    public class GeneticDiseasesController : AppControllerBase
    {
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return NewResult(await Mediator.Send(new DeleteGeneticDiseasesCommand(id)));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateGeneticDiseasesCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<IActionResult> Update(AddGeneticDiseasesCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetByPatientId(Guid patientId)
        {
            return NewResult(await Mediator.Send(new GetGeneticDiseasesByPatientIdQuery(patientId)));
        }
    }
}