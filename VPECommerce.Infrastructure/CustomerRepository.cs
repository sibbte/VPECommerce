﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPECommerce.Application.Interfaces;
using VPECommerce.Domain.Models;
using VPECommerce.Infrastructure.MyEcommerceApp.Infrastructure;

namespace VPECommerce.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly VPECommerceDbContext _context;

        public CustomerRepository(VPECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

    }
}
