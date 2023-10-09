using Ecommerce.Domain.Entities.Categories;
using Ecommerce.Domain.Repositories;
using Ecommerce.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Include(Category category)
        {
            try
            {
                _context.Categories.Add(category);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories;
        }

        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(p => p.Id == id);
        }
    }
}
