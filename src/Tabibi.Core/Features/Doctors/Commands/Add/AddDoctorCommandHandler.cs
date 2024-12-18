using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Clinics;
using Tabibi.Domain.Clinics.Entities.Doctors;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Doctors.Commands.Add
{
    public sealed class AddDoctorCommandHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<AddDoctorCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

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

            _unitOfWork.DoctorRepository.Add(doctor);
            _unitOfWork.ClinicRepository.Add(clinic);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success(doctor.Id);
        }
    }
}
