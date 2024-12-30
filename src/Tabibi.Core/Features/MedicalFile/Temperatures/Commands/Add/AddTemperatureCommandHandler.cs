using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Patients.Entities;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalFile.Temperatures.Commands.Add
{
    public sealed class AddTemperatureCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<AddTemperatureCommand, Result<Guid>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<Guid>> Handle(AddTemperatureCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var temperature = Temperature.Create(
                request.Value,
                request.Notes,
                request.PatientId,
                userId);

            _unitOfWork.TemperatureRepository.Add(temperature);
            await _unitOfWork.SaveChangesAsync();
            return Result.Created(temperature.Id);
        }
    }
}