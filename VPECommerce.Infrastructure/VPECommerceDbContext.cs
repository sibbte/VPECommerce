using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VPECommerce.Domain.Models;

namespace VPECommerce.Infrastructure
{
    namespace MyEcommerceApp.Infrastructure
    {
        public class VPECommerceDbContext : DbContext
        {
            private readonly IConfiguration _configuration;

            public VPECommerceDbContext(DbContextOptions<VPECommerceDbContext> options)
                : base(options)
            {
            }

            public DbSet<Customer> Customers { get; set; }
            public DbSet<OrderItem> OrderItems { get; set; }
            public DbSet<Order> Orders { get; set; }
            public DbSet<Product> Products { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                
            }

        }
    }
}
