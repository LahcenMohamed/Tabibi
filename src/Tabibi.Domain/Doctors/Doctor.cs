using Tabibi.Domain.Doctors.Enums;
using Tabibi.Domain.Doctors.ValueObjects;
using Tabibi.Domain.Shared.Entities;
using Tabibi.Domain.Shared.Enums;
using Tabibi.Domain.Shared.ValueObjects;

namespace Tabibi.Domain.Doctors
{
    public sealed class Doctor : FullAuditedEntity
    {
        public FullName FullName { get; private set; }
        public Gender Gender { get; private set; }
        public DateOnly DateOfBirth { get; private set; }
        public Specialization Specialization { get; private set; }
        public int ExperienceYears { get; private set; }
        public string LicenseNumber { get; private set; }
        public string[] PhoneNumbers { get; private set; }
        public string EmailAddress { get; private set; }
        public Address Address { get; private set; }
        public double Rating { get; private set; }
        public string? PhotoUrl { get; private set; }
        public string? Notes { get; private set; }
        public Guid UserId { get; private set; }

        private Doctor()
        {
            // Private constructor to enforce factory pattern.
        }

        public static Doctor Create(
            FullName fullName,
            Gender gender,
            DateOnly dateOfBirth,
            Specialization specialization,
            int experienceYears,
            string licenseNumber,
            string[] phoneNumbers,
            string emailAddress,
            Address address,
            double rating,
            string? notes,
            string? photoUrl,
            Guid userId)
        {

            return new Doctor
            {
                FullName = fullName,
                Gender = gender,
                DateOfBirth = dateOfBirth,
                Specialization = specialization,
                ExperienceYears = experienceYears,
                LicenseNumber = licenseNumber,
                PhoneNumbers = phoneNumbers,
                EmailAddress = emailAddress,
                Address = address,
                Rating = rating,
                Notes = notes,
                PhotoUrl = photoUrl,
                CreatedAt = DateTime.Now,
                CreatedBy = userId,
                UserId = userId
            };
        }

        public void Update(
            FullName fullName,
            Gender gender,
            DateOnly dateOfBirth,
            Specialization specialization,
            int experienceYears,
            string licenseNumber,
            string[] phoneNumbers,
            string emailAddress,
            Address address,
            double rating,
            string? notes,
            string? photoUrl,
            Guid UserId)
        {

            FullName = fullName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Specialization = specialization;
            ExperienceYears = experienceYears;
            LicenseNumber = licenseNumber;
            PhoneNumbers = phoneNumbers;
            EmailAddress = emailAddress;
            Address = address;
            Rating = rating;
            Notes = notes;
            PhotoUrl = photoUrl;
            LastModifiedAt = DateTime.Now;
            LastModifiedBy = UserId;
        }
    }

}
