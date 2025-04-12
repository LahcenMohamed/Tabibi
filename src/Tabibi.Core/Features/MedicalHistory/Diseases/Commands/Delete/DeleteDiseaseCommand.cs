using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalHistory.Diseases.Commands.Delete
{
    public sealed record DeleteDiseaseCommand(Guid Id) : IRequest<Result<string>>;
}