using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalFile.Temperatures.Queries
{
    public sealed class GetTemperaturesQueryHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<GetTemperaturesQuery, Result<List<GetTemperaturesQueryResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<List<GetTemperaturesQueryResponse>>> Handle(GetTemperaturesQuery request, CancellationToken cancellationToken)
        {
            var temperatures = _unitOfWork.TemperatureRepository.GetByPatientId<GetTemperaturesQueryResponse>(request.PatientId);
            return temperatures.ToList();
        }
    }
}