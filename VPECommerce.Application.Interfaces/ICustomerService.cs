using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPECommerce.Domain.Models;

namespace VPECommerce.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerByIdAsync(Guid id);

    }
}
