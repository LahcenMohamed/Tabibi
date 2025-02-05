using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalFile.Temperatures.Commands.Delete
{
    public sealed record DeleteTemperatureCommand(Guid Id) : IRequest<Result<string>>;
}
