using MediatR;
using Tabibi.Domain.Clinics.Enums;
using Tabibi.Domain.Clinics.ValueObjects;
using Tabibi.Domain.Shared.Enums;
using Tabibi.Domain.Shared.Results;
using Tabibi.Domain.Shared.ValueObjects;

namespace Tabibi.Core.Features.Doctors.Commands.Add
{
    public sealed record AddDoctorCommand(FullName FullName,
                                          Gender Gender,
                                          DateOnly DateOfBirth,
                                          string PhoneNumber,
                                          string EmailAddress,
                                          string? Notes,
                                          string Name,
                                          Specialization Specialization,
                                          string ClinicPhoneNumber,
                                          string? SecondPhoneNumber,
                                          string ClinicEmail,
                                          Address Address,
                                          string? MinDescription,
                                          Guid UserId) : IRequest<Result<Guid>>;
}
