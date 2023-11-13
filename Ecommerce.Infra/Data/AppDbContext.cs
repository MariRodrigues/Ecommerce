using Ecommerce.Domain.Entities.Categories;
using Ecommerce.Domain.Entities.Products;
using Ecommerce.Domain.Entities.ShoppingCart;
using Ecommerce.Domain.Entities.Subcategories;
using Ecommerce.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infra.Data
{
    public class AppDbContext : DbContext
    {
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

            modelBuilder.Entity<CartItem>()
                .HasOne(ps => ps.Product)
                .WithMany(s => s.CartItems)
                .HasForeignKey(ps => ps.ProductId);

            //modelBuilder.Entity<Address>()
            //    .HasKey(a => a.Id);

            //modelBuilder.Entity<CustomerInfo>()
            //    .HasKey(ci => ci.Id);

            //modelBuilder.Entity<CustomerInfo>()
            //    .HasOne(ci => ci.Address)
            //    .WithOne(a => a.CustomerInfo)
            //    .HasForeignKey<Address>(a => a.CustomerInfoId);

            //modelBuilder.Entity<CustomerInfo>()
            //    .HasOne(c => c.User)
            //    .WithOne(u => u.CustomerInfo)
            //    .HasForeignKey<CustomerInfo>(c => c.UserId);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSubcategory> ProductSubcategories { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        //public DbSet<Address> Addresses { get; set; }
        //public DbSet<CustomerInfo> CustomerInfos { get; set; }
    }
}
