using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Patients.Entities;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalHistory.Allergies.Commands.Add
{
    public sealed class AddAllergyCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<AddAllergyCommand, Result<Guid>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<Guid>> Handle(AddAllergyCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var addiction = Allergy.Create(request.Name, request.PatientId, userId);
            _unitOfWork.AllergyRepository.Add(addiction);
            await _unitOfWork.SaveChangesAsync();
            return Result.Created(addiction.Id);
        }
    }
}
