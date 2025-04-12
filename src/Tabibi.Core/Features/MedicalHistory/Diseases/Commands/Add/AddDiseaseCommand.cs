using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalHistory.Diseases.Commands.Add
{
    public sealed record AddDiseaseCommand(Guid PatientId, string Name, DateOnly StartDate, DateOnly EndDate) : IRequest<Result<Guid>>;
}