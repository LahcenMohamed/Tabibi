using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Doctors.Queries.GetAll
{
    public sealed class GetAllDoctorsQueryHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<GetAllDoctorsQuery, Result<List<GetAllDoctorsQueryResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<List<GetAllDoctorsQueryResponse>>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
        {
            var doctors = _unitOfWork.DoctorRepository.GetAllWithDto<GetAllDoctorsQueryResponse>();
            return doctors.ToList();
        }
    }
}
