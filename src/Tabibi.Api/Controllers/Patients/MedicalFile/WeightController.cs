using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabibi.Api.Bases;
using Tabibi.Core.Features.MedicalFile.Weights.Commands.Add;
using Tabibi.Core.Features.MedicalFile.Weights.Commands.Delete;
using Tabibi.Core.Features.MedicalFile.Weights.Commands.Update;
using Tabibi.Core.Features.MedicalFile.Weights.Queries;

namespace Tabibi.Api.Controllers.Patients.MedicalFile
{
    [Route("api/patients/weights")]
    [ApiController]
    [Authorize(Roles = "Patient")]
    public sealed class WeightController : AppControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddWeight(AddWeightCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWeight(UpdateWeightCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteWeight(Guid id)
        {
            var result = await Mediator.Send(new DeleteWeightCommand(id));
            return NewResult(result);
        }

        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetWeights(Guid patientId)
        {
            var result = await Mediator.Send(new GetWeightsQuery(patientId));
            return NewResult(result);
        }
    }
}
