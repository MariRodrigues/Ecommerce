using Ecommerce.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities.Orders
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Subtotal { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
