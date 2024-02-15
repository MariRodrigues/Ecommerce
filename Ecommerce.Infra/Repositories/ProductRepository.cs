using Ecommerce.Domain.Entities.Products;
using Ecommerce.Domain.Repositories;
using Ecommerce.Infra.Data;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Product> GetAll(string? name)
        {
            if (name == null)
            {
                return _context.Products.Include(a => a.Images);
            }

            return _context.Products.Where(p => p.Name.Contains(name)).Include(a => a.Images);
        }

        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
