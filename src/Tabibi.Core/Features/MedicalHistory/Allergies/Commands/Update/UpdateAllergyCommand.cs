using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalHistory.Allergies.Commands.Update
{
    public sealed record UpdateAllergyCommand(Guid Id, string Name) : IRequest<Result<string>>;
}