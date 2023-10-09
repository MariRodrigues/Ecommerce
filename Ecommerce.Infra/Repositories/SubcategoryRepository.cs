using Ecommerce.Domain.Entities.Categories;
using Ecommerce.Domain.Entities.Subcategories;
using Ecommerce.Domain.Repositories;
using Ecommerce.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Repositories
{
    public class SubcategoryRepository : ISubcategoryRepository
    {
        private readonly AppDbContext _context;

        public SubcategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Subcategory> GetAll()
        {
            return _context.Subcategories;
        }

        public Subcategory GetById(int id)
        {
            return _context.Subcategories.FirstOrDefault(p => p.Id == id);
        }

        public void Include(Subcategory subcategory)
        {
            try
            {
                _context.Subcategories.Add(subcategory);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
