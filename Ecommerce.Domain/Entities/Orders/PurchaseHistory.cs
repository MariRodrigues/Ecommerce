using Ecommerce.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities.Orders
{
    public class PurchaseHistory
    {
        public int Id { get; set; }
        public CustomUser User { get; set; }
        public int UserId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
