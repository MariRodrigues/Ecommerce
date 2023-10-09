using Ecommerce.Domain.Entities.Categories;
using Ecommerce.Domain.Entities.Subcategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Repositories
{
    public interface ISubcategoryRepository
    {
        void Include(Subcategory category);
        IEnumerable<Subcategory> GetAll();
        Subcategory GetById(int id);
    }
}
