using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabibi.Api.Bases;
using Tabibi.Core.Features.MedicalFile.Heights.Commands.Add;
using Tabibi.Core.Features.MedicalFile.Heights.Queries;

namespace Tabibi.Api.Controllers.Patients.MedicalFile
{
    [Route("api/patients/heights")]
    [ApiController]
    [Authorize(Roles = "Patient")]
    public sealed class HeightController : AppControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddHeight(AddHeightCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetHeights(Guid patientId)
        {
            var result = await Mediator.Send(new GetHeightsQuery(patientId));
            return Ok(result);
        }
    }
}
