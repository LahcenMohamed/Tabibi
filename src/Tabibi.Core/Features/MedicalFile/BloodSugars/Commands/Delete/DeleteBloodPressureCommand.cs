using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalFile.BloodSugars.Commands.Delete
{
    public sealed record DeleteBloodSugarCommand(Guid Id) : IRequest<Result<string>>;
}
