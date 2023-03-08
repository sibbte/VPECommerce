using Microsoft.AspNetCore.Mvc;
using VPECommerce.Application.Interfaces;
using VPECommerce.Application.Validators;
using VPECommerce.Domain.Dtos;
using VPECommerce.Domain.Models;

namespace VPECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public ActionResult<Order> CreateOrder(OrderDto orderDto)
        {
            // Validate the incoming order data using FluentValidation
            OrderDtoValidator validator = new OrderDtoValidator();
            var validationResult = validator.Validate(orderDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            // Map the OrderDto to an Order domain object
            Order order = new Order
            {
                Customer = new Customer
                {
                    Name = orderDto.Customer.Name,
                    Email = orderDto.Customer.Email,
                    PhoneNumber = orderDto.Customer.PhoneNumber,
                },
                OrderItems = (IEnumerable<OrderItem>)orderDto.OrderItems
            };

            // Save the order to the SQL database using the OrderService
            _orderService.PlaceOrderAsync(order);

            // Return the newly created order as an HTTP response
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById(Guid id)
        {
            // Retrieve the order with the given ID from the SQL database using the OrderService
            Order order = _orderService.GetOrderById(id);

            // If the order doesn't exist, return a 404 Not Found response
            if (order == null)
            {
                return NotFound();
            }

            // Otherwise, return the order as an HTTP response
            return Ok(order);
        }
    }
}

