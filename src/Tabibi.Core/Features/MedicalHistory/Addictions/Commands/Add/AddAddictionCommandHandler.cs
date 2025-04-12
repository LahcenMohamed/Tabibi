using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Patients.Entities;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalHistory.Addictions.Commands.Add
{
    public sealed class AddAddictionCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<AddAddictionCommand, Result<Guid>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<Guid>> Handle(AddAddictionCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var addiction = Addiction.Create(request.Name, request.PatientId, userId);
            _unitOfWork.AddictionRepository.Add(addiction);
            await _unitOfWork.SaveChangesAsync();
            return Result.Created(addiction.Id);
        }
    }
}
