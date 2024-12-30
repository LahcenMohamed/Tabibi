using MediatR;
using Microsoft.AspNetCore.Identity;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Patients;
using Tabibi.Domain.Shared.Results;
using Tabibi.Domain.Users;

namespace Tabibi.Core.Features.Patients.Commands.Add
{
    public sealed class AddPatientCommandHandler(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        : IRequestHandler<AddPatientCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        public async Task<Result<Guid>> Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {
            var patient = Patient.Create(
                request.FullName,
                request.Gender,
                request.BirthDate,
                request.PhoneNumber,
                request.Email,
                request.UserId,
                true);

            var user = _userManager.Users.FirstOrDefault(x => x.Id == request.UserId);
            if (user is null)
            {
                return Result.NotFound();
            }

            _unitOfWork.PatientRepository.Add(patient);

            await _userManager.AddToRoleAsync(user, "Patient");
            await _unitOfWork.SaveChangesAsync();

            return Result.Created(patient.Id);
        }
    }
}
