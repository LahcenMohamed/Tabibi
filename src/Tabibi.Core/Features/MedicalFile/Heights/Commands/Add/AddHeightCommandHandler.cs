using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Patients.Entities;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalFile.Heights.Commands.Add
{
    public sealed class AddHeightCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<AddHeightCommand, Result<Guid>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<Guid>> Handle(AddHeightCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var height = Height.Create(
                request.Value,
                request.Notes,
                request.PatientId,
                userId);

            _unitOfWork.HeightRepository.Add(height);
            await _unitOfWork.SaveChangesAsync();
            return Result.Created(height.Id);
        }
    }
}