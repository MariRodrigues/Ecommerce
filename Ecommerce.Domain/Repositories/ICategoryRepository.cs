using Ecommerce.Domain.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Repositories
{
    public interface ICategoryRepository
    {
        void Include(Category category);
        IEnumerable<Category> GetAll();
        Category GetById(int id);
    }
}
