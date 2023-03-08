using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPECommerce.Domain.Dtos
{
    public class OrderDto
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public CustomerDto Customer { get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; }
    }
}
