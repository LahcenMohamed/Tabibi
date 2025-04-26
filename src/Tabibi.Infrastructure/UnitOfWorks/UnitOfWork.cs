using Microsoft.Extensions.Configuration;
using Tabibi.Infrastructure.DbContexts;
using Tabibi.Infrastructure.Features.Appointments;
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
using Tabibi.Infrastructure.Features.WorkSchedules;

namespace Reygency.Infrastructure.UnitOfWorks
{
    public sealed class UnitOfWork : IUnitOfWork
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
        public IWorkScheduleRepository WorkScheduleRepository { get; }
        public IAppointmentRepository AppointmentRepository { get; }

        private readonly TabibiDbContext _context;
        private readonly IConfiguration _configuration;

        public UnitOfWork(TabibiDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

            // Initialize repositories
            ClinicRepository = new ClinicRepository(context, _configuration);
            DoctorRepository = new DoctorRepository(context, _configuration);
            JobTimeRepository = new JobTimeRepository(context, _configuration);
            EmployeeRepository = new EmployeeRepository(context, configuration);
            PatientRepository = new PatientRepository(context, _configuration);
            BloodPressureRepository = new BloodPressureRepository(context, _configuration);
            BloodSugarRepository = new BloodSugarRepository(context, _configuration);
            HeightRepository = new HeightRepository(context, _configuration);
            WeightRepository = new WeightRepository(context, _configuration);
            TemperatureRepository = new TemperatureRepository(context, _configuration);
            AddictionRepository = new AddictionRepository(context, _configuration);
            AllergyRepository = new AllergyRepository(context, _configuration);
            GeneticDiseaseRepository = new GeneticDiseaseRepository(context, _configuration);
            ChronicDiseaseRepository = new ChronicDiseaseRepository(context, _configuration);
            DiseaseRepository = new DiseaseRepository(context, _configuration);
            WorkScheduleRepository = new WorkScheduleRepository(context, _configuration);
            AppointmentRepository = new AppointmentRepository(context, _configuration);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}