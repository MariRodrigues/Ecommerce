using Ecommerce.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Repositories
{
    public interface IProductSubcategoryRepository
    {
        void Include(ProductSubcategory productSubcategory);
    }
}
