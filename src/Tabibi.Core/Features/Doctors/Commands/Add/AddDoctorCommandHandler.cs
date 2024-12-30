using MediatR;
using Microsoft.AspNetCore.Identity;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Clinics;
using Tabibi.Domain.Clinics.Entities.Doctors;
using Tabibi.Domain.Shared.Results;
using Tabibi.Domain.Users;

namespace Tabibi.Core.Features.Doctors.Commands.Add
{
    public sealed class AddDoctorCommandHandler(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        : IRequestHandler<AddDoctorCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        public async Task<Result<Guid>> Handle(AddDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = Doctor.Create(request.FullName,
                                       request.Gender,
                                       request.DateOfBirth,
                                       request.PhoneNumber,
                                       request.EmailAddress,
                                       request.Notes,
                                       null,
                                       request.UserId);

            var clinic = Clinic.Create(request.Name,
                                       request.Specialization,
                                       request.ClinicPhoneNumber,
                                       request.ClinicEmail,
                                       request.Address,
                                       request.UserId,
                                       request.MinDescription,
                                       request.SecondPhoneNumber);

            doctor.Connect(clinic, clinic.Id);
            clinic.Connect(doctor, doctor.Id);

            var user = _userManager.Users.FirstOrDefault(x => x.Id == request.UserId);
            if (user is null)
            {
                return Result.NotFound();
            }
            _unitOfWork.DoctorRepository.Add(doctor);
            _unitOfWork.ClinicRepository.Add(clinic);
            await userManager.AddToRoleAsync(user, "Doctor");
            await _unitOfWork.SaveChangesAsync();

            return Result.Created(doctor.Id);
        }
    }
}
