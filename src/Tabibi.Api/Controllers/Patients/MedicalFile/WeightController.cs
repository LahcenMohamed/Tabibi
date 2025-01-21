using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabibi.Api.Bases;
using Tabibi.Core.Features.MedicalFile.Weights.Commands.Add;
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
            return Ok(result);
        }

        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetWeights(Guid patientId)
        {
            var result = await Mediator.Send(new GetWeightsQuery(patientId));
            return Ok(result);
        }
    }
}
