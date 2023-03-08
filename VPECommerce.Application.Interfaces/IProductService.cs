using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPECommerce.Domain.Models;

namespace VPECommerce.Application.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProductByIdAsync(Guid id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        // Additional methods for adding, updating, and deleting products, etc.
    }
}
