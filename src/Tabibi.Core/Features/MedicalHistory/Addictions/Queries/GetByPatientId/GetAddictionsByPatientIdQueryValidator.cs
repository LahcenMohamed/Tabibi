using FluentValidation;

namespace Tabibi.Core.Features.MedicalHistory.Addictions.Queries.GetByPatientId
{
    public sealed class GetAddictionsByPatientIdQueryValidator : AbstractValidator<GetAddictionsByPatientIdQuery>
    {
        public GetAddictionsByPatientIdQueryValidator()
        {
            RuleFor(x => x.PatientId)
                .NotEmpty().WithMessage("Patient Id is required");
        }
    }
}