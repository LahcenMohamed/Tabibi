using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Patients.Entities;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalFile.BloodSugars.Commands.Add
{
    public sealed class AddBloodSugarCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<AddBloodSugarCommand, Result<Guid>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<Guid>> Handle(AddBloodSugarCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var bloodSugar = BloodSugar.Create(
                request.Value,
                request.Notes,
                request.PatientId,
                userId);

            _unitOfWork.BloodSugarRepository.Add(bloodSugar);
            await _unitOfWork.SaveChangesAsync();
            return Result.Created(bloodSugar.Id);
        }
    }
}