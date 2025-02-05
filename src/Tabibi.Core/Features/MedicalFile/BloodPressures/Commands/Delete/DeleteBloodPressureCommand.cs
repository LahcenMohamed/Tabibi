using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalFile.BloodPressures.Commands.Delete
{
    public sealed record DeleteBloodPressureCommand(Guid Id) : IRequest<Result<string>>;
}
