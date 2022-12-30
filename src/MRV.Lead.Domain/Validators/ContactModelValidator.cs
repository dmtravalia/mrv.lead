using FluentValidation;
using MRV.Lead.Domain.Models;

namespace MRV.Lead.Domain.Validators;

public class ContactModelValidator : AbstractValidator<ContactModel>
{
    public ContactModelValidator()
    {
        RuleFor(c => c.FullName)
            .NotEmpty().WithMessage("FullName cannot be empty.")
            .NotNull().WithMessage("FullName must be informed.");

        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Email cannot be empty.")
            .NotNull().WithMessage("Email must be informed.")
            .EmailAddress();
    }
}