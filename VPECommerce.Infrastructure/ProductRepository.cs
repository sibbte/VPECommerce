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
    public class ProductRepository : IProductRepository
    {
        private readonly VPECommerceDbContext _context;

        public ProductRepository(VPECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
