using Ecommerce.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Repositories
{
    public interface IProductSizesRepository
    {
        void Include(ProductSize productsize);

        void Include(List<ProductSize> sizeList);
    }
}
