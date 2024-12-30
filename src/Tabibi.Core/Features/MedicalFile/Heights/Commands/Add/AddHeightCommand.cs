using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalFile.Heights.Commands.Add
{
    public sealed record AddHeightCommand(Guid PatientId, decimal Value, string? Notes)
        : IRequest<Result<Guid>>;
}