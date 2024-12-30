using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Clinics.Queries.GetAll
{
    public sealed class GetAllClinicsQueryHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<GetAllClinicsQuery, Result<List<GetAllClinicsQueryResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<List<GetAllClinicsQueryResponse>>> Handle(GetAllClinicsQuery request, CancellationToken cancellationToken)
        {
            var clinics = _unitOfWork.ClinicRepository.GetAllWithDto<GetAllClinicsQueryResponse>(request.Specialization, request.State, request.City);
            return clinics.ToList();
        }
    }
}
