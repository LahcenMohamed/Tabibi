using Tabibi.Domain.Clinics.Entities.Doctors;
using Tabibi.Domain.Clinics.Entities.JobTimes;
using Tabibi.Domain.Clinics.Enums;
using Tabibi.Domain.Clinics.ValueObjects;
using Tabibi.Domain.Shared.AggregateRoots;

namespace Tabibi.Domain.Clinics
{
    public sealed class Clinic : FullAuditedAggregateRoot
    {
        public string Name { get; set; }
        public string? MinDescription { get; set; }
        public Specialization Specialization { get; private set; }
        public string PhoneNumber { get; private set; }
        public string? SecondPhoneNumber { get; private set; }
        public string Email { get; private set; }
        public Address Address { get; set; }
        public string? PhotoUrl { get; private set; }
        public Guid DoctorId { get; private set; }
        public Doctor Doctor { get; private set; }
        public Guid UserId { get; private set; }
        public List<JobTime> jobTimes { get; private set; }

        private Clinic() { }

        public static Clinic Create(
            string name,
            Specialization specialization,
            string phoneNumber,
            string email,
            Address address,
            Guid userId,
            string? minDescription = null,
            string? secondPhoneNumber = null,
            string? photoUrl = null)
        {
            return new Clinic
            {
                Name = name,
                Specialization = specialization,
                PhoneNumber = phoneNumber,
                Email = email,
                Address = address,
                MinDescription = minDescription,
                SecondPhoneNumber = secondPhoneNumber,
                PhotoUrl = photoUrl,
                UserId = userId,
                CreatedAt = DateTime.Now,
                CreatedBy = userId
            };
        }

        public void Update(
            string name,
            string? minDescription,
            Specialization specialization,
            string phoneNumber,
            string? secondPhoneNumber,
            string email,
            Address address,
            Guid userId,
            string? photoUrl = null)
        {
            Name = name;
            MinDescription = minDescription;
            Specialization = specialization;
            PhoneNumber = phoneNumber;
            SecondPhoneNumber = secondPhoneNumber;
            Email = email;
            Address = address;
            PhotoUrl = photoUrl;
            LastModifiedAt = DateTime.Now;
            LastModifiedBy = userId;
        }

        public void Connect(Doctor doctor, Guid doctorId)
        {
            Doctor = doctor;
            DoctorId = doctorId;
        }
    }
}
