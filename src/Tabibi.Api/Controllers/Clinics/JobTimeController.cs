﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabibi.Api.Bases;
using Tabibi.Core.Features.JobTimes.Commands.Add;
using Tabibi.Core.Features.JobTimes.Commands.Delete;
using Tabibi.Core.Features.JobTimes.Commands.Update;
using Tabibi.Core.Features.JobTimes.Queries.Get;

namespace Tabibi.Api.Controllers.Clinics
{
    [Route("api/clinic/job-time")]
    [ApiController]
    [Authorize(Roles = "Doctor")]
    public class JobTimeController : AppControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await Mediator.Send(new GetJobTimesQuery());
            return NewResult(response);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(AddJobTimeCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateJobTimeCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await Mediator.Send(new DeleteJobTimeCommand(id));
            return NewResult(response);
        }
    }
}
