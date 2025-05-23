﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabibi.Api.Bases;
using Tabibi.Core.Features.Patients.Commands.Add;
using Tabibi.Core.Features.Patients.Commands.AddRelative;
using Tabibi.Core.Features.Patients.Queries.GetOwner;
using Tabibi.Core.Features.Patients.Queries.GetRelatives;

namespace Tabibi.Api.Controllers.Patients
{
    [Route("api/patients")]
    [ApiController]
    [Authorize(Roles = "Patient")]
    public class PatientController : AppControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(AddPatientCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPost("relatives")]
        public async Task<IActionResult> CreateRelative(AddRelativePatientCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetOwner()
        {
            var response = await Mediator.Send(new GetOwnerPatientQuery());
            return NewResult(response);
        }

        [HttpGet("relatives")]
        public async Task<IActionResult> GetRelatives()
        {
            var response = await Mediator.Send(new GetRelativesQuery());
            return NewResult(response);
        }
    }
}
