using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabibi.Api.Bases;
using Tabibi.Core.Features.MedicalHistory.Allergies.Commands.Add;
using Tabibi.Core.Features.MedicalHistory.Allergies.Commands.Delete;
using Tabibi.Core.Features.MedicalHistory.Allergies.Commands.Update;
using Tabibi.Core.Features.MedicalHistory.Allergies.Queries.GetByPatientId;

namespace Tabibi.Api.Controllers.Patients.MedicalHistory;

[Authorize]
[Route("api/patients/medical-history/allergies")]
public class AllergyController : AppControllerBase
{

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return NewResult(await Mediator.Send(new DeleteAllergyCommand(id)));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateAllergyCommand command)
    {
        return NewResult(await Mediator.Send(command));
    }

    [HttpPost]
    public async Task<IActionResult> Update(AddAllergyCommand command)
    {
        return NewResult(await Mediator.Send(command));
    }

    [HttpGet("patient/{patientId}")]
    public async Task<IActionResult> GetByPatientId(Guid patientId)
    {
        return NewResult(await Mediator.Send(new GetAllergiesByPatientIdQuery(patientId)));
    }
}