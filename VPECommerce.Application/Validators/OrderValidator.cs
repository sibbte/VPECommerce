using FluentValidation;
using FluentValidation.Results;
using VPECommerce.Domain.Dtos;
using VPECommerce.Domain.Models;

namespace VPECommerce.Application.Validators
{
    namespace MyEcommerceApp.Application.Validators
    {
        public class OrderValidator : AbstractValidator<Order>
        {
            public OrderValidator()
            {
                RuleFor(order => order.Customer)
                    .NotNull()
                    .WithMessage("Customer information is required.");

                RuleFor(order => order.OrderItems)
                    .NotNull()
                    .WithMessage("Order must contain at least one product.");

                RuleForEach(order => order.OrderItems)
                    .ChildRules(products =>
                    {
                        products.RuleFor(product => product.Quantity)
                            .GreaterThan(0)
                            .WithMessage("Product quantity must be greater than 0.");

                        products.RuleFor(product => product.Product)
                            .NotNull()
                            .WithMessage("Product information is required.");
                    });
            }
            public override ValidationResult Validate(ValidationContext<Order> context)
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
}
