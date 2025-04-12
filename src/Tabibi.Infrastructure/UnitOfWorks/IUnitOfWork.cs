using Tabibi.Infrastructure.Features.Clinics;
using Tabibi.Infrastructure.Features.Doctors;
using Tabibi.Infrastructure.Features.Employees;
using Tabibi.Infrastructure.Features.JobTimes;
using Tabibi.Infrastructure.Features.MedicalFile.BloodPressures;
using Tabibi.Infrastructure.Features.MedicalFile.BloodSugars;
using Tabibi.Infrastructure.Features.MedicalFile.Heights;
using Tabibi.Infrastructure.Features.MedicalFile.Temperatures;
using Tabibi.Infrastructure.Features.MedicalFile.Weights;
using Tabibi.Infrastructure.Features.MedicalHistory.Addictions;
using Tabibi.Infrastructure.Features.MedicalHistory.Allergies;
using Tabibi.Infrastructure.Features.MedicalHistory.ChronicDiseases;
using Tabibi.Infrastructure.Features.MedicalHistory.Diseases;
using Tabibi.Infrastructure.Features.MedicalHistory.GeneticDiseases;
using Tabibi.Infrastructure.Features.Patients;

namespace Reygency.Infrastructure.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        public IClinicRepository ClinicRepository { get; }
        public IDoctorRepository DoctorRepository { get; }
        public IJobTimeRepository JobTimeRepository { get; }
        public IEmployeeRepository EmployeeRepository { get; }
        public IPatientRepository PatientRepository { get; }
        public IBloodPressureRepository BloodPressureRepository { get; }
        public IBloodSugarRepository BloodSugarRepository { get; }
        public IHeightRepository HeightRepository { get; }
        public IWeightRepository WeightRepository { get; }
        public ITemperatureRepository TemperatureRepository { get; }
        public IAddictionRepository AddictionRepository { get; }
        public IAllergyRepository AllergyRepository { get; }
        public IGeneticDiseaseRepository GeneticDiseaseRepository { get; }
        public IChronicDiseaseRepository ChronicDiseaseRepository { get; }
        public IDiseaseRepository DiseaseRepository { get; }

        Task<int> SaveChangesAsync();
    }
}