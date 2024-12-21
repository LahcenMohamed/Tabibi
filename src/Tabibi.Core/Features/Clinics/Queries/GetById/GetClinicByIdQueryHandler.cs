using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Core.Features.Clinics.Queries.GetAll;
using Tabibi.Core.Features.Doctors.Queries.GetAll;
using Tabibi.Core.Features.JobTimes.Queries.Get;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Clinics.Queries.GetById
{
    public sealed class GetClinicByIdQueryHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<GetClinicByIdQuery, Result<GetClinicByIdQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<GetClinicByIdQueryResponse>> Handle(GetClinicByIdQuery request, CancellationToken cancellationToken)
        {
            var clinic = _unitOfWork.ClinicRepository.GetByIdDapper<GetAllClinicsQueryResponse>(request.Id);
            if (clinic is null)
            {
                return Result.NotFound<GetClinicByIdQueryResponse>(null);
            }
            var doctor = _unitOfWork.DoctorRepository.GetByClinicId<GetAllDoctorsQueryResponse>(request.Id);
            var jobTimes = _unitOfWork.JobTimeRepository.GetAllByClinicId<JobTimeResponse>(request.Id).ToList();

            var response = new GetClinicByIdQueryResponse { Clinic = clinic, Doctor = doctor, JobTimes = jobTimes };
            return Result.Success(response);
        }
    }
}
