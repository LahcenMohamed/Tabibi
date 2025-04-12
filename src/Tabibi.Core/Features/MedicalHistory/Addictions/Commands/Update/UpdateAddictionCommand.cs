using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalHistory.Addictions.Commands.Update
{
    public sealed record UpdateAddictionCommand(Guid Id, string Name) : IRequest<Result<string>>;
}