using FinalMvcNet.Models.ViewModels;
using FluentValidation;

namespace FinalMvcNet.Models.Validators;

public class SprintValidator : AbstractValidator<SprintViewModel>
{
    public SprintValidator()
    {
        RuleFor(s => s.Name)
            .NotEmpty().WithMessage("Sprint Name is required.")
            .MaximumLength(100).WithMessage("Sprint Name cannot exceed 100 characters.");

        RuleFor(s => s.StartDate)
            .NotEmpty().WithMessage("Start Date is required.")
            .LessThan(s => s.EndDate).WithMessage("Start Date must be before End Date.");

        RuleFor(s => s.EndDate)
            .NotEmpty().WithMessage("End Date is required.")
            .GreaterThan(s => s.StartDate).WithMessage("End Date must be after Start Date.");

        RuleFor(s => s.ProjectId)
            .GreaterThan(0).WithMessage("A valid Project must be selected.");
    }
}