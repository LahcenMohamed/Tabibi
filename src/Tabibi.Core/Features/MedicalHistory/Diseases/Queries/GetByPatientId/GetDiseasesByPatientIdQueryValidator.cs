using FluentValidation;

namespace Tabibi.Core.Features.MedicalHistory.Diseases.Queries.GetByPatientId
{
    public sealed class GetDiseasesByPatientIdQueryValidator : AbstractValidator<GetDiseasesByPatientIdQuery>
    {
        public GetDiseasesByPatientIdQueryValidator()
        {
            RuleFor(x => x.PatientId).NotEmpty();
        }
    }
}