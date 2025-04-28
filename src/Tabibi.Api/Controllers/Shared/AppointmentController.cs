using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabibi.Api.Bases;
using Tabibi.Core.Features.Appointments.Commands.Add;
using Tabibi.Core.Features.Appointments.Commands.CancelAppointment;
using Tabibi.Core.Features.Appointments.Commands.ConfirmAppointment;
using Tabibi.Core.Features.Appointments.Commands.Delete;
using Tabibi.Core.Features.Appointments.Commands.Update;
using Tabibi.Core.Features.Appointments.Queries.GetByWorkScheduleId;

namespace Tabibi.Api.Controllers.Shared
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AppointmentController : AppControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(AddAppointmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> Create(UpdateAppointmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Create(Guid id)
        {
            var response = await Mediator.Send(new DeleteAppointmentCommand(id));
            return NewResult(response);
        }

        [HttpGet("{workScheduleId:guid}")]
        public async Task<IActionResult> GetAll(Guid workScheduleId)
        {
            var response = await Mediator.Send(new GetByWorkScheduleIdQuery(workScheduleId));
            
            return NewResult(response);
        }

        [HttpPatch("confirm/{id:guid}")]
        public async Task<IActionResult> Confirm(Guid id)
        {
            var response = await Mediator.Send(new ConfirmAppointmentCommand(id));
            return NewResult(response);
        }
        
        
        [HttpPatch("cancel/{id:guid}")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            var response = await Mediator.Send(new CancelAppointmentCommand(id));
            return NewResult(response);
        }
    }
}