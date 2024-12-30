using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Patients;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.Patients.Commands.AddRelative
{
    public sealed class AddRelativePatientCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<AddRelativePatientCommand, Result<Guid>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<Guid>> Handle(AddRelativePatientCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var patient = Patient.Create(
                request.FullName,
                request.Gender,
                request.BirthDate,
                request.PhoneNumber,
                request.Email,
                userId,
                false,
                request.FamilyLink,
                request.State,
                request.City);

            _unitOfWork.PatientRepository.Add(patient);
            await _unitOfWork.SaveChangesAsync();

            return Result.Created(patient.Id);
        }
    }
}
