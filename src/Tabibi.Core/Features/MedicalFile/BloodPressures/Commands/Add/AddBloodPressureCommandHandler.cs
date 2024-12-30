using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Patients.Entities;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalFile.BloodPressures.Commands.Add
{
    public sealed class AddBloodPressureCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<AddBloodPressureCommand, Result<Guid>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<Guid>> Handle(AddBloodPressureCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var bloodPerssures = BloodPressure.Create(
                request.MinValue,
                request.MaxValue,
                request.Notes,
                request.PatientId,
                userId);

            _unitOfWork.BloodPressureRepository.Add(bloodPerssures);
            await _unitOfWork.SaveChangesAsync();
            return Result.Created(bloodPerssures.Id);
        }
    }
}
