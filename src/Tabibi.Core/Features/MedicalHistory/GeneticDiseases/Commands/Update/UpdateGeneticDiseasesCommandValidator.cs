﻿using FluentValidation;

namespace Tabibi.Core.Features.MedicalHistory.GeneticDiseases.Commands.Update
{
    public sealed class UpdateGeneticDiseasesCommandValidator : AbstractValidator<UpdateGeneticDiseasesCommand>
    {
        public UpdateGeneticDiseasesCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Chronic disease ID is required");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters");
        }
    }
}
