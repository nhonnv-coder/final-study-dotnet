using FinalMvcNet.Models.ViewModels;
using FluentValidation;

namespace FinalMvcNet.Models.Validators;

public class TestSuiteValidator : AbstractValidator<TestSuiteViewModel>
{
    public TestSuiteValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Test Suite Name is required.")
            .MaximumLength(100).WithMessage("Test Suite Name cannot exceed 100 characters.");

        RuleFor(x => x.SprintId)
            .GreaterThan(0).WithMessage("Please select a valid Sprint.");
    }
}