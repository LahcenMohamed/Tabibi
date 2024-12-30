using Microsoft.Extensions.Configuration;
using Tabibi.Infrastructure.DbContexts;
using Tabibi.Infrastructure.Features.Clinics;
using Tabibi.Infrastructure.Features.Doctors;
using Tabibi.Infrastructure.Features.Employees;
using Tabibi.Infrastructure.Features.JobTimes;
using Tabibi.Infrastructure.Features.MedicalFile.BloodPressures;
using Tabibi.Infrastructure.Features.MedicalFile.BloodSugars;
using Tabibi.Infrastructure.Features.MedicalFile.Heights;
using Tabibi.Infrastructure.Features.MedicalFile.Temperatures;
using Tabibi.Infrastructure.Features.MedicalFile.Weights;
using Tabibi.Infrastructure.Features.Patients;

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