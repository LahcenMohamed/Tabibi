using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalFile.BloodSugars.Commands.Update
{
    public sealed record UpdateBloodSugarCommand(Guid Id, decimal Value, string? Notes)
        : IRequest<Result<string>>;
}
