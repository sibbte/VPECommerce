using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPECommerce.Application.Interfaces;
using VPECommerce.Domain.Models;
using VPECommerce.Infrastructure.MyEcommerceApp.Infrastructure;

namespace VPECommerce.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        private readonly VPECommerceDbContext _context;

        public OrderRepository(VPECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
