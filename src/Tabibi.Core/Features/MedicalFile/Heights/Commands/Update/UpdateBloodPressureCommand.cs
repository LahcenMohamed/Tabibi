using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalFile.Heights.Commands.Update
{
    public sealed record UpdateHeightCommand(Guid Id, decimal Value, string? Notes)
        : IRequest<Result<string>>;
}
