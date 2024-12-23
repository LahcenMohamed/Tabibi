using Microsoft.AspNetCore.Mvc;
using Tabibi.Api.Bases;
using Tabibi.Core.Features.Employees.Commands.Add;
using Tabibi.Core.Features.Employees.Commands.Delete;
using Tabibi.Core.Features.Employees.Commands.Update;
using Tabibi.Core.Features.Employees.Queries.GetAll;

namespace Tabibi.Api.Controllers.Clinics
{
    [Route("api/employees")]
    [ApiController]
    public sealed class EmployeeController : AppControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(AddEmployeeCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> Create(UpdateEmployeeCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Create(Guid id)
        {
            var response = await Mediator.Send(new DeleteEmployeeCommand(id));
            return NewResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await Mediator.Send(new GetAllEmployeesQuery());
            return NewResult(response);
        }

    }
}
