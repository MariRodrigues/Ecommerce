using Ecommerce.Domain.Entities.Products;
using Ecommerce.Domain.Repositories;
using Ecommerce.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public Product Include(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return product;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }

        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
