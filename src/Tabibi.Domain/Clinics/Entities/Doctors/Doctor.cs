using Tabibi.Domain.Shared.Entities;
using Tabibi.Domain.Shared.Enums;
using Tabibi.Domain.Shared.ValueObjects;

namespace Tabibi.Domain.Clinics.Entities.Doctors
{
    public sealed class Doctor : FullAuditedEntity
    {
        public FullName FullName { get; private set; }
        public Gender Gender { get; private set; }
        public DateOnly DateOfBirth { get; private set; }
        public string PhoneNumber { get; private set; }
        public string EmailAddress { get; private set; }
        public string? PhotoUrl { get; private set; }
        public string? Notes { get; private set; }
        public Guid ClinicId { get; private set; }
        public Clinic Clinic { get; private set; }

        private Doctor()
        {
            // Private constructor to enforce factory pattern.
        }

        public static Doctor Create(
            FullName fullName,
            Gender gender,
            DateOnly dateOfBirth,
            string phoneNumber,
            string emailAddress,
            string? notes,
            string? photoUrl,
            Guid userId)
        {

            return new Doctor
            {
                FullName = fullName,
                Gender = gender,
                DateOfBirth = dateOfBirth,
                PhoneNumber = phoneNumber,
                EmailAddress = emailAddress,
                Notes = notes,
                PhotoUrl = photoUrl,
                CreatedAt = DateTime.Now,
                CreatedBy = userId
            };
        }

        public void Update(
            FullName fullName,
            Gender gender,
            DateOnly dateOfBirth,
            string phoneNumber,
            string emailAddress,
            double rating,
            string? notes,
            string? photoUrl,
            Guid UserId)
        {

            FullName = fullName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            Notes = notes;
            PhotoUrl = photoUrl;
            LastModifiedAt = DateTime.Now;
            LastModifiedBy = UserId;
        }

        public void AddFullName(FullName fullName)
        {
            FullName = fullName;
        }

        public void Connect(Clinic clinic, Guid clinicId)
        {
            Clinic = clinic;
            ClinicId = clinicId;
        }
    }

}
