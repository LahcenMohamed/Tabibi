using FluentAssertions;
using Refit;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tabibi.Core.Features.Authenfications.Commands.Signup;
using Tabibi.Core.Features.Doctors.Commands.Add;
using Tabibi.Domain.Clinics.Enums;
using Tabibi.Domain.Clinics.ValueObjects;
using Tabibi.Domain.Shared.Enums;
using Tabibi.Domain.Shared.Results;
using Tabibi.Domain.Shared.ValueObjects;

namespace Tabibi.IntegrationTests.Doctors
{
    public class DoctorControllerTests : BaseIntegrationTest
    {
        private readonly HttpClient _client;
        //private readonly IDoctorApi _doctorApi;

        public DoctorControllerTests(IntegrationTestWebAppFactory factory)
            : base(factory)
        {
            var settings = new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
                {
                    Converters = { new JsonStringEnumConverter() }
                })
            };
            // _doctorApi = RestService.For<IDoctorApi>(factory.CreateClient(), settings);
            _client = factory.CreateClient();

        }

        [Fact]
        public async Task Create_Doctor_ShouldReturnSuccessResponse()
        {
            // Arrange
            // First create a user account
            var signupCommand = new SignupCommand("John", "0558892473", "john@gmall.com");
            var userResult = await Sender.Send(signupCommand);
            var userId = Guid.Parse(userResult.Data);

            var createDoctorRequest = new AddDoctorCommand(
                FullName: new FullName(
                    FirstName: "John",
                    MiddelName: "Michael",
                    LastName: "Doe"
                ),
                Gender: Gender.Male,
                DateOfBirth: new DateOnly(1985, 5, 20),
                PhoneNumber: "123-456-7890",
                EmailAddress: "john.doe@example.com",
                Notes: "Experienced in family medicine",
                Name: "Dr. John Doe Clinic",
                Specialization: Specialization.Anesthesiologist,
                ClinicPhoneNumber: "321-654-0987",
                SecondPhoneNumber: "555-123-4567",
                ClinicEmail: "clinic@example.com",
                Address: new Address(
                    State: "New York",
                    City: "New York City",
                    Street: "123 Main Street",
                    UrlOnMap: "Near Central Park"
                ),
                MinDescription: "A brief description about the doctor",
                UserId: userId);

            // Act
            var response = await _client.PostAsJsonAsync("/api/clinic/doctors", createDoctorRequest);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var jsonResponse = await response.Content.ReadFromJsonAsync<Result<Guid?>>();
            jsonResponse.Succeeded.Should().BeTrue();
            jsonResponse.Data.Should().NotBe(Guid.Empty);

        }

        [Fact]
        public async Task Create_Doctor_WithInvalidData_ShouldReturnUnprocessableEntity()
        {
            // Arrange
            var invalidRequest = new AddDoctorCommand(
                FullName: new FullName("", "", ""), // Invalid empty names
                Gender: Gender.Male,
                DateOfBirth: new DateOnly(2025, 1, 1), // Future date
                PhoneNumber: "",  // Invalid empty phone
                EmailAddress: "invalid-email", // Invalid email format
                Notes: null,
                Name: "",  // Invalid empty clinic name
                Specialization: Specialization.Anesthesiologist,
                ClinicPhoneNumber: "",
                SecondPhoneNumber: null,
                ClinicEmail: "invalid-email",
                Address: new Address("", "", "", null), // Invalid empty address
                MinDescription: null,
                UserId: Guid.Empty); // Invalid empty user ID

            // Act
            var response = await _client.PostAsJsonAsync("/api/clinic/doctors", invalidRequest);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
            var content = await response.Content.ReadFromJsonAsync<Result<Guid?>>();
            content.Should().NotBeNull();
            content!.Succeeded.Should().BeFalse();
            content.Error.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Create_Doctor_WithInvalidUserId_ShouldReturnNotFound()
        {

            var createDoctorRequest = new AddDoctorCommand(
                FullName: new FullName(
                    FirstName: "John",
                    MiddelName: "Michael",
                    LastName: "Doe"
                ),
                Gender: Gender.Male,
                DateOfBirth: new DateOnly(1985, 5, 20),
                PhoneNumber: "123-456-7890",
                EmailAddress: "john.doe@example.com",
                Notes: "Experienced in family medicine",
                Name: "Dr. John Doe Clinic",
                Specialization: Specialization.Anesthesiologist,
                ClinicPhoneNumber: "321-654-0987",
                SecondPhoneNumber: "555-123-4567",
                ClinicEmail: "clinic@example.com",
                Address: new Address(
                    State: "New York",
                    City: "New York City",
                    Street: "123 Main Street",
                    UrlOnMap: "Near Central Park"
                ),
                MinDescription: "A brief description about the doctor",
                UserId: Guid.CreateVersion7());

            // Act
            var response = await _client.PostAsJsonAsync("/api/clinic/doctors", createDoctorRequest);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            var jsonResponse = await response.Content.ReadFromJsonAsync<Result<Guid?>>();
            jsonResponse.Succeeded.Should().BeFalse();
            jsonResponse.Error.Should().NotBeEmpty();

        }
    }
}
