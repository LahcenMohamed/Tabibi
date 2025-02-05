using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalFile.Temperatures.Commands.Update
{
    public sealed record UpdateTemperatureCommand(Guid Id, decimal Value, string? Notes)
        : IRequest<Result<string>>;
}
