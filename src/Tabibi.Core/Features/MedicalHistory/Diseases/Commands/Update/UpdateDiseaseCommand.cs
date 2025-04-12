using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalHistory.Diseases.Commands.Update
{
    public sealed record UpdateDiseaseCommand(Guid Id, string Name, DateOnly StartDate, DateOnly EndDate) : IRequest<Result<string>>;
}