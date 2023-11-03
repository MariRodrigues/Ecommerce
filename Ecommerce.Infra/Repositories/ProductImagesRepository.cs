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
    public class ProductImagesRepository : IProductImagesRepository
    {
        private readonly AppDbContext _context;

        public ProductImagesRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Include (ProductImages productImages)
        {
            _context.ProductImages.Add(productImages);
        }

        public void Include(List<ProductImages> imageList)
        {
            _context.ProductImages.AddRange(imageList);
        }
    }
}
