using Ecommerce.Domain.Entities.Products;
using System.Collections.Generic;

namespace Ecommerce.Domain.Repositories
{
    public interface IProductImagesRepository
    {
        void Include(ProductImages productImages);
        void Include(List<ProductImages> productImages);
    }
}
