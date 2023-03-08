using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPECommerce.Application.Interfaces;
using VPECommerce.Application.Validators.MyEcommerceApp.Application.Validators;
using VPECommerce.Domain.Models;

namespace VPECommerce.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }

        public Order GetOrderById(Guid id)
        {
            return _orderRepository.GetByIdAsync(id).Result;
        }

        public async Task<Order> PlaceOrderAsync(Order order)
        {
            // Validate the order before processing it
            var orderValidator = new OrderValidator();
            var validationResult = orderValidator.Validate(order);
            if (!validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(validationResult.Errors);
            }

            // Check that all of the products in the order exist and have sufficient inventory
            foreach (var orderItems in order.OrderItems)
            {
                var product = await _productRepository.GetByIdAsync(orderItems.Id);
                if (product == null)
                {
                    throw new InvalidOperationException($"Product {orderItems.Id} not found.");
                }
                if (product.InventoryLevel < orderItems.Quantity)
                {
                    throw new InvalidOperationException($"Insufficient inventory for product {orderItems.Id}.");
                }
            }

            // Update the inventory levels for the products in the order
            foreach (var orderItems in order.OrderItems)
            {
                var product = await _productRepository.GetByIdAsync(orderItems.Id);
                product.InventoryLevel -= orderItems.Quantity;
                await _productRepository.UpdateAsync(product);
            }

            // Add the order to the database
            await _orderRepository.AddAsync(order);

            return order;
        }
    }
}
