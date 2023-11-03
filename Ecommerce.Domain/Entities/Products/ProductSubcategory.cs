using Ecommerce.Domain.Entities.Subcategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities.Products
{
    public class ProductSubcategory
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int SubcategoryId { get; set; }
        public virtual Subcategory Subcategory { get; set; }

        public ProductSubcategory(int productId, int subcategoryId)
        {
            ProductId = productId;
            SubcategoryId = subcategoryId;
        }
    }
}
