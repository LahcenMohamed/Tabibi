﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Tabibi.Domain.Clinics;
using Tabibi.Domain.Clinics.Entities.Doctors;
using Tabibi.Domain.Clinics.Entities.JobTimes;
using Tabibi.Domain.Employees;
using Tabibi.Domain.Employees.Entities.EmployeeJobTimes;
using Tabibi.Domain.Patients;
using Tabibi.Domain.Patients.Entities;
using Tabibi.Domain.Users;
using Tabibi.Domain.WorkSchedules;
using Tabibi.Domain.WorkSchedules.Entities.Appointments;

namespace Tabibi.Infrastructure.DbContexts
{
    public class TabibiDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<JobTime> JobTimes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeJobTime> EmployeeJobTimes { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<BloodPressure> BloodPressures { get; set; }
        public DbSet<BloodSugar> BloodSugars { get; set; }
        public DbSet<Height> Heights { get; set; }
        public DbSet<Weight> Weights { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<GeneticDisease> GeneticDiseases { get; set; }
        public DbSet<Addiction> Addictions { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<ChronicDisease> ChronicDiseases { get; set; }
        public DbSet<WorkSchedule> WorkSchedules { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public TabibiDbContext()
        {

        }

        public TabibiDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(TabibiDbContext).Assembly);
            base.OnModelCreating(builder);
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                    {
                        property.SetColumnType("timestamp without time zone");
                    }
                }
            }
        }
    }

    
}
