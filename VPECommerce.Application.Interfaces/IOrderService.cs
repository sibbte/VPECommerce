using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPECommerce.Domain.Models;

namespace VPECommerce.Application.Interfaces
{
    public interface IOrderService
    {
        Order GetOrderById(Guid id);
        Task<Order> PlaceOrderAsync(Order order);
        // Additional methods for updating and canceling orders, etc.
    }
}
