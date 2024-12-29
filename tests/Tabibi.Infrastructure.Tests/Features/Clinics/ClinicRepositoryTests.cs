using Microsoft.Extensions.Configuration;
using Moq;
using Tabibi.Domain.Clinics.Enums;
using Tabibi.Infrastructure.DbContexts;
using Tabibi.Infrastructure.Features.Clinics;

// is not working
public class ClinicRepositoryTests
{
    private readonly Mock<TabibiDbContext> _mockContext;
    private readonly Mock<IConfiguration> _mockConfiguration;
    private readonly ClinicRepository _repository;

    public ClinicRepositoryTests()
    {
        _mockContext = new Mock<TabibiDbContext>();
        _mockConfiguration = new Mock<IConfiguration>();

        var connectionStringsSection = new Mock<IConfigurationSection>();
        var defaultConnectionSection = new Mock<IConfigurationSection>();

        connectionStringsSection
            .Setup(x => x.GetSection("DefaultConnection"))
            .Returns(defaultConnectionSection.Object);
        defaultConnectionSection
            .Setup(x => x.Value)
            .Returns("Server=test;Database=TestDb;Trusted_Connection=True;");

        _mockConfiguration
            .Setup(x => x.GetSection("ConnectionStrings"))
            .Returns(connectionStringsSection.Object);

        _repository = new ClinicRepository(_mockContext.Object, _mockConfiguration.Object);
    }

    [Theory]
    [InlineData(Specialization.Endocrinologist, "New York", "Manhattan")]
    [InlineData(Specialization.Obstetrician, "California", "Los Angeles")]
    public void GetAllWithDto_ShouldReturnFilteredClinics(Specialization specialization, string state, string city)
    {
        // Arrange
        var expectedClinics = new List<TestClinicDto>
        {
            new TestClinicDto
            {
                Id = 1,
                Name = "Test Clinic",
                Specialization = specialization,
                State = state,
                City = city
            }
        };

        // Act
        var result = _repository.GetAllWithDto<TestClinicDto>(specialization, state, city);

        // Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IQueryable<TestClinicDto>>(result);
    }

    [Fact]
    public void GetAllWithDto_WithInvalidParameters_ShouldReturnEmptyResult()
    {
        // Arrange
        var specialization = Specialization.Geriatrician;
        var state = "NonExistentState";
        var city = "NonExistentCity";

        // Act
        var result = _repository.GetAllWithDto<TestClinicDto>(specialization, state, city);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    private class TestClinicDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Specialization Specialization { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}