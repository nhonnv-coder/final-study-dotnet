using FinalMvcNet.Models.ViewModels;
using FluentValidation;

namespace FinalMvcNet.Models.Validators;

public class ProjectValidator : AbstractValidator<ProjectViewModel>
{
    public ProjectValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Project name is required")
            .MaximumLength(100).WithMessage("Project name cannot exceed 100 characters");

        RuleFor(p => p.StartDate)
            .NotEmpty().WithMessage("Start date is required")
            .LessThanOrEqualTo(p => p.EndDate).WithMessage("Start date must be before or equal to end date");

        RuleFor(p => p.EndDate)
            .NotEmpty().WithMessage("End date is required");

        RuleFor(p => p.Status)
            .IsInEnum().WithMessage("Invalid Status value");

        RuleFor(p => p.ImageFile)
            .Must(file => file == null || (file.ContentType.StartsWith("image/") && file.Length < 5 * 1024 * 1024))
            .WithMessage("Only image files under 5MB are allowed");
    }
}