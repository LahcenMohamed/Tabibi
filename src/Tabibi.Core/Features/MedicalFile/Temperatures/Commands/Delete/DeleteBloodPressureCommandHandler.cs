using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalFile.Temperatures.Commands.Delete
{
    public sealed class DeleteTemperatureCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<DeleteTemperatureCommand, Result<string>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<string>> Handle(DeleteTemperatureCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var temperature = _unitOfWork.TemperatureRepository.GetById(request.Id);
            if (temperature is null)
            {
                return Result.NotFound();
            }

            _unitOfWork.TemperatureRepository.Delete(temperature, userId);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success(string.Empty);
        }
    }
}
