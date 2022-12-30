using FluentValidation;
using MRV.Lead.Domain.Models;

namespace MRV.Lead.Domain.Validators;

public class LeadModelValidator : AbstractValidator<LeadModel>
{
    public LeadModelValidator()
    {
        RuleFor(c => c.Description)
            .NotEmpty().WithMessage("Description cannot be empty.")
            .NotNull().WithMessage("Description must be informed.");

        RuleFor(c => c.Price)
            .NotEmpty().WithMessage("Price cannot be empty.")
            .NotNull().WithMessage("Price must be informed.");

        RuleFor(c => c.Suburb)
            .NotEmpty().WithMessage("Suburb cannot be empty.")
            .NotNull().WithMessage("Suburb must be informed.");

        RuleFor(c => c.Status)
            .NotEmpty().WithMessage("Status cannot be empty.")
            .NotNull().WithMessage("Status must be informed.");

        RuleFor(c => c.ContactID)
            .NotEmpty().WithMessage("ContactID cannot be empty.")
            .NotNull().WithMessage("ContactID must be informed.");
    }
}