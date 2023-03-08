using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPECommerce.Domain.Dtos;

namespace VPECommerce.Application.Validators
{
    public class OrderDtoValidator : AbstractValidator<OrderDto>
    {
        public OrderDtoValidator()
        {
            RuleFor(order => order.OrderNumber)
                .NotEmpty().WithMessage("Order number is required.");

            RuleFor(order => order.OrderDate)
                .NotEmpty().WithMessage("Order date is required.")
                .LessThan(DateTime.Now).WithMessage("Order date cannot be in the future.");

            RuleFor(order => order.Customer)
                .NotNull().WithMessage("Customer information is required.")
                .SetValidator(new CustomerDtoValidator());

            RuleForEach(order => order.OrderItems)
                    .ChildRules(products =>
                    {
                        products.RuleFor(product => product.ProductId)
                            .NotNull()
                            .WithMessage("Product quantity must be greater than 0.");

                        products.RuleFor(product => product.Quantity)
                            .GreaterThan(0)
                            .WithMessage("Product information is required.");
                    });
        }
        public override ValidationResult Validate(ValidationContext<OrderDto> context)
        {
            var result = base.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            return result;
        }
    }
}
