﻿using Ecommerce.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities.ShoppingCart
{
    public class CartItem
    {
        public int Id { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public virtual Cart Cart { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
    }
}
