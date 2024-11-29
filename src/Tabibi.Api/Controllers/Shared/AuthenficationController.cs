using Microsoft.AspNetCore.Mvc;
using Tabibi.Api.Bases;
using Tabibi.Core.Features.Authenfications.Commands.ConfirmEmail;
using Tabibi.Core.Features.Authenfications.Commands.ResetPassword;
using Tabibi.Core.Features.Authenfications.Commands.SendResetPasswordToken;
using Tabibi.Core.Features.Authenfications.Commands.Signin;
using Tabibi.Core.Features.Authenfications.Commands.Signup;

namespace Tabibi.Api.Controllers.Authenfications
{
    [Route("api/authenfication")]
    [ApiController]
    public class AuthenficationController : AppControllerBase
    {
        [HttpPost("signin")]
        public async Task<IActionResult> Signin(SigninCommand request)
        {
            var result = await Mediator.Send(request);
            return NewResult(result);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup(SignupCommand request)
        {
            var result = await Mediator.Send(request);
            return NewResult(result);
        }

        [HttpPut("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailCommand request)
        {
            var result = await Mediator.Send(request);
            return NewResult(result);
        }

        [HttpPut("send-reset-password-code")]
        public async Task<IActionResult> SendRestPasswordToken(SendResetPasswordTokenCommand request)
        {
            var result = await Mediator.Send(request);
            return NewResult(result);
        }

        [HttpPut("reset-password")]
        public async Task<IActionResult> RestPassword(ResetPasswordCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }
    }
}
