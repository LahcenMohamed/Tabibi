using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalHistory.ChronicDiseases.Commands.Delete
{
    public sealed record DeleteChronicDiseaseCommand(Guid Id) : IRequest<Result<string>>;
}