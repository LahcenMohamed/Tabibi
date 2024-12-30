using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalFile.Temperatures.Queries
{
    public sealed record GetTemperaturesQuery(Guid PatientId)
        : IRequest<Result<List<GetTemperaturesQueryResponse>>>;
}