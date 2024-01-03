using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Domain.Entities.Products;
using Ecommerce.Domain.Entities.Subcategories;
using Ecommerce.Domain.Entities.Categories;

namespace Ecommerce.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSubcategory> ProductSubcategories { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subcategory>()
                .HasOne(subcategoria => subcategoria.Category)
                .WithMany(categoria => categoria.Subcategories)
                .HasForeignKey(subcategoria => subcategoria.CategoryId);

            modelBuilder.Entity<ProductImages>()
                .HasOne(image => image.Product)
                .WithMany(product => product.Images)
                .HasForeignKey(image => image.ProductId);

            modelBuilder.Entity<ProductSubcategory>()
                .HasKey(ps => new { ps.ProductId, ps.SubcategoryId });

            modelBuilder.Entity<ProductSubcategory>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ProductSubcategories)
                .HasForeignKey(ps => ps.ProductId);

            modelBuilder.Entity<ProductSubcategory>()
                .HasOne(ps => ps.Subcategory)
                .WithMany(s => s.ProductSubcategories)
                .HasForeignKey(ps => ps.SubcategoryId);

            modelBuilder.Entity<ProductSubcategory>()
                .HasKey(ps => new { ps.ProductId, ps.SubcategoryId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
