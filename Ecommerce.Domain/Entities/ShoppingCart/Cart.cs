using System.Collections.Generic;

namespace Ecommerce.Domain.Entities.ShoppingCart
{
    public class Cart
    {
        public int Id { get; set; }
        public virtual List<CartItem> Items { get; set; }
    }
}
