using Microsoft.AspNetCore.Mvc;
using Tabibi.Api.Bases;
using Tabibi.Core.Features.Doctors.Commands.Add;
using Tabibi.Core.Features.Doctors.Queries.GetAll;

namespace Tabibi.Api.Controllers.Clinics
{
    [Route("api/clinic/doctors")]
    [ApiController]
    public sealed class DoctorController : AppControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(AddDoctorCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await Mediator.Send(new GetAllDoctorsQuery());
            return NewResult(response);
        }
    }
}
