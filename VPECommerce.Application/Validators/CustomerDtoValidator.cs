using FluentValidation;
using FluentValidation.Validators;
using VPECommerce.Domain.Dtos;

namespace VPECommerce.Application.Validators
{
    public class CustomerDtoValidator : AbstractValidator<CustomerDto>
    {
        public CustomerDtoValidator()
        {
            RuleFor(customer => customer.Name)
                .NotEmpty().WithMessage("Customer name is required.")
                .MaximumLength(100).WithMessage("Customer name cannot exceed 100 characters.");

            RuleFor(customer => customer.Email)
                .NotEmpty().WithMessage("Customer email is required.")
                .EmailAddress().WithMessage("Invalid email address.")
                .MaximumLength(100).WithMessage("Customer email cannot exceed 100 characters.");

            RuleFor(customer => customer.PhoneNumber)
                .NotEmpty().WithMessage("Customer phone number is required.")
                .Matches(@"^[0-9]+$").WithMessage("Invalid phone number.")
                .MaximumLength(20).WithMessage("Customer phone number cannot exceed 20 characters.");
        }
    }
}