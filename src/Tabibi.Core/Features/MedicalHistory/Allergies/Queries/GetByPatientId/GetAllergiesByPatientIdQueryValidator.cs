using FluentValidation;

namespace Tabibi.Core.Features.MedicalHistory.Allergies.Queries.GetByPatientId
{
    public sealed class GetAllergiesByPatientIdQueryValidator : AbstractValidator<GetAllergiesByPatientIdQuery>
    {
        public GetAllergiesByPatientIdQueryValidator()
        {
            RuleFor(x => x.PatientId).NotEmpty();
        }
    }
}