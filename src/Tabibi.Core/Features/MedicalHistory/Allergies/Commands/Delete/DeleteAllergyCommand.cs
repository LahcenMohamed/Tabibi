using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalHistory.Allergies.Commands.Delete
{
    public sealed record DeleteAllergyCommand(Guid Id) : IRequest<Result<string>>;
}