using Ecommerce.Domain.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Queries
{
    public interface ICategoryQueries
    {
        Task<IEnumerable<CategorySubcategoryViewModel>> GetCategoryWithSubcategories();
        Task<IEnumerable<CategorySubcategoryViewModel>> GetCategoryWithProducts();
    }
}
