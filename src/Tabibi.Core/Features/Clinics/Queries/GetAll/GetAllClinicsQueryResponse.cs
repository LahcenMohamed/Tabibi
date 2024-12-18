using Tabibi.Domain.Clinics.Enums;

namespace Tabibi.Core.Features.Clinics.Queries.GetAll
{
    public sealed class GetAllClinicsQueryResponse
    {
        public string Name { get; set; }
        public string? MinDescription { get; set; }
        public Specialization Specialization { get; set; }
        public string PhoneNumber { get; set; }
        public string? SecondPhoneNumber { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string? Note { get; set; }
        public string? PhotoUrl { get; set; }
        public Guid DoctorId { get; set; }
    }
}
