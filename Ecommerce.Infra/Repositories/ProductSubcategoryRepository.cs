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
    public class ProductSubcategoryRepository : IProductSubcategoryRepository
    {
        private readonly AppDbContext _context;

        public ProductSubcategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Include(ProductSubcategory productSubcategory)
        {
            try
            {
                _context.ProductSubcategories.Add(productSubcategory);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
