using Tabibi.Domain.Shared.AggregateRoots;
using Tabibi.Domain.Shared.Enums;

namespace Tabibi.Domain.Patients
{
    public sealed class Patient : FullAuditedAggregateRoot
    {
        public string FullName { get; private set; }
        public Gender Gender { get; private set; }
        public DateOnly BirthDate { get; private set; }
        public string? State { get; private set; }
        public string? City { get; private set; }
        public string? PhoneNumber { get; private set; }
        public string? Email { get; private set; }
        public bool IsOwner { get; private set; }
        public FamilyLink? FamilyLink { get; private set; }
        public Guid UserId { get; private set; }

        private Patient()
        {
        }

        public static Patient Create(
            string fullName,
            Gender gender,
            DateOnly birthDate,
            string? phoneNumber,
            string? email,
            Guid userId,
            bool isOwner = false,
            FamilyLink? familyLink = null,
            string? state = null,
            string? city = null)
        {
            return new Patient
            {
                FullName = fullName,
                Gender = gender,
                BirthDate = birthDate,
                PhoneNumber = phoneNumber,
                Email = email,
                UserId = userId,
                State = state,
                City = city,
                IsOwner = isOwner,
                FamilyLink = familyLink,
            };
        }

        public void Update(
            string fullName,
            Gender gender,
            DateOnly birthDate,
            string phoneNumber,
            string email,
            string? state = null,
            string? city = null)
        {
            FullName = fullName;
            Gender = gender;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Email = email;
            State = state;
            City = city;
        }
    }

    public enum FamilyLink : byte
    {
        Father,
        Mother,
        Sister,
        Brother,
        Son,
        Daughter,
        Uncle,
        Aunt,
        Cousin,
        GrandFather,
        GrandMother,
        Other
    }

}
