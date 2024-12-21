using Microsoft.AspNetCore.Mvc;
using Tabibi.Api.Bases;
using Tabibi.Core.Features.Clinics.Queries.GetAll;
using Tabibi.Core.Features.Clinics.Queries.GetById;

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

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAll(Guid id)
        {
            var response = await Mediator.Send(new GetClinicByIdQuery(id));
            return NewResult(response);
        }
    }
}
