using Ecommerce.Domain.Entities.Products;
using Ecommerce.Domain.Repositories;
using Ecommerce.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Repositories
{
    public class ProductSizesRepository : IProductSizesRepository
    {
        private readonly AppDbContext _context;

        public ProductSizesRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Include(ProductSize productsize)
        {
            _context.ProductSizes.Add(productsize);
        }

        public void Include(List<ProductSize> sizeList)
        {
            _context.ProductSizes.AddRange(sizeList);
        }
    }
}
