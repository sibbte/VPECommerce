using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPECommerce.Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
        public int TotalCost { get; set; } 
    }
}
