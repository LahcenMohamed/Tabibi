using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalHistory.ChronicDiseases.Commands.Update
{
    public sealed record UpdateChronicDiseaseCommand(Guid Id, string Name) : IRequest<Result<string>>;
}