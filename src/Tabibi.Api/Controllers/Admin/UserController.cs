using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabibi.Api.Bases;
using Tabibi.Core.Features.Users.Commands.AddAdmin;
using Tabibi.Core.Features.Users.Commands.DeleteUser;
using Tabibi.Core.Features.Users.Queries.GetAll;
using Tabibi.Core.Features.Users.Queries.GetById;
using Tabibi.Core.Features.Users.Queries.GetByPagination;

namespace Reygency.Api.Controllers.Admin
{
    [Route("api/admin/users")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : AppControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAdmin(AddAdminCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllUsersQuery());
            return NewResult(result);
        }

        [HttpGet("pagination")]
        public async Task<IActionResult> GetByPagination([FromQuery] GetUsersByPaginationQuery query)
        {
            var result = await Mediator.Send(query);
            return NewResult(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await Mediator.Send(new GetUserByIdQuery(id));
            return NewResult(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await Mediator.Send(new DeleteUserCommand(id));
            return NewResult(result);
        }
    }
}
