using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabibi.Api.Bases;
using Tabibi.Core.Features.WorkSchedules.Commands.Add;
using Tabibi.Core.Features.WorkSchedules.Commands.Delete;
using Tabibi.Core.Features.WorkSchedules.Commands.Update;
using Tabibi.Core.Features.WorkSchedules.Queries.GetAll;

namespace Tabibi.Api.Controllers.Clinics;

[ApiController]
[Route("api/work-schedule")]
[Authorize(Roles ="Doctor")]
public class WorkScheduleController : AppControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(AddWorkScheduleCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut]
    public async Task<IActionResult> Create(UpdateWorkScheduleCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Create(Guid id)
    {
        var response = await Mediator.Send(new DeleteWorkScheduleCommand(id));
        return NewResult(response);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllWorkScheduleQuery query)
    {
        var response = await Mediator.Send(query);
        return NewResult(response);
    }
}
