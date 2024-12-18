using Microsoft.AspNetCore.Mvc;
using Tabibi.Api.Bases;
using Tabibi.Core.Features.Clinics.Queries.GetAll;

namespace Tabibi.Api.Controllers.Clinics
{
    [Route("api/clinics")]
    [ApiController]
    public class ClinicsController : AppControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllClinicsQuery query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
    }
}
