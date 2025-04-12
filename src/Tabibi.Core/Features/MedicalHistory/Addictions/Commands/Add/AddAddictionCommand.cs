using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalHistory.Addictions.Commands.Add
{
    public sealed record AddAddictionCommand(Guid PatientId, string Name) : IRequest<Result<Guid>>;
}
