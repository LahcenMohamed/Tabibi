using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalFile.Heights.Commands.Delete
{
    public sealed record DeleteHeightCommand(Guid Id) : IRequest<Result<string>>;
}
