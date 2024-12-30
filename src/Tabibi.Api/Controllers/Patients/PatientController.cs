using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabibi.Api.Bases;
using Tabibi.Core.Features.MedicalFile.BloodPressures.Commands.Add;
using Tabibi.Core.Features.MedicalFile.BloodPressures.Queries.Get;
using Tabibi.Core.Features.MedicalFile.BloodSugars.Commands.Add;
using Tabibi.Core.Features.MedicalFile.BloodSugars.Queries;
using Tabibi.Core.Features.MedicalFile.Heights.Commands.Add;
using Tabibi.Core.Features.MedicalFile.Heights.Queries;
using Tabibi.Core.Features.MedicalFile.Temperatures.Commands.Add;
using Tabibi.Core.Features.MedicalFile.Temperatures.Queries;
using Tabibi.Core.Features.MedicalFile.Weights.Commands.Add;
using Tabibi.Core.Features.MedicalFile.Weights.Queries;
using Tabibi.Core.Features.Patients.Commands.Add;
using Tabibi.Core.Features.Patients.Commands.AddRelative;

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

        [HttpGet("blood-pressures/{patientId}")]
        public async Task<IActionResult> GetBloodPressures(Guid patientId)
        {
            var result = await Mediator.Send(new GetBloodPressuresQuery(patientId));
            return Ok(result);
        }

        [HttpGet("blood-sugars/{patientId}")]
        public async Task<IActionResult> GetBloodSugars(Guid patientId)
        {
            var result = await Mediator.Send(new GetBloodSugarsQuery(patientId));
            return Ok(result);
        }

        [HttpGet("heights/{patientId}")]
        public async Task<IActionResult> GetHeights(Guid patientId)
        {
            var result = await Mediator.Send(new GetHeightsQuery(patientId));
            return Ok(result);
        }

        [HttpGet("weights/{patientId}")]
        public async Task<IActionResult> GetWeights(Guid patientId)
        {
            var result = await Mediator.Send(new GetWeightsQuery(patientId));
            return Ok(result);
        }

        [HttpGet("temperatures/{patientId}")]
        public async Task<IActionResult> GetTemperatures(Guid patientId)
        {
            var result = await Mediator.Send(new GetTemperaturesQuery(patientId));
            return Ok(result);
        }

        [HttpPost("blood-pressures")]
        public async Task<IActionResult> AddBloodPressure(AddBloodPressureCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("blood-sugars")]
        public async Task<IActionResult> AddBloodSugar(AddBloodSugarCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("heights")]
        public async Task<IActionResult> AddHeight(AddHeightCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("weights")]
        public async Task<IActionResult> AddWeight(AddWeightCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("temperatures")]
        public async Task<IActionResult> AddTemperature(AddTemperatureCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
