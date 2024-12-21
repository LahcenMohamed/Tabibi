using Tabibi.Core.Features.Clinics.Queries.GetAll;
using Tabibi.Core.Features.Doctors.Queries.GetAll;
using Tabibi.Core.Features.JobTimes.Queries.Get;

namespace Tabibi.Core.Features.Clinics.Queries.GetById
{
    public class GetClinicByIdQueryResponse
    {
        public GetAllClinicsQueryResponse Clinic { get; set; }
        public GetAllDoctorsQueryResponse Doctor { get; set; }
        public List<JobTimeResponse> JobTimes { get; set; }
    }
}
