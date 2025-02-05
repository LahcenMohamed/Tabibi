using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalFile.Temperatures.Commands.Update
{
    public sealed class UpdateTemperatureCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateTemperatureCommand, Result<string>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<string>> Handle(UpdateTemperatureCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var temperature = _unitOfWork.TemperatureRepository.GetById(request.Id);
            if (temperature is null)
            {
                return Result.NotFound();
            }
            temperature.Update(request.Value, request.Notes, userId);
            _unitOfWork.TemperatureRepository.Update(temperature);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success(string.Empty);
        }
    }
}
