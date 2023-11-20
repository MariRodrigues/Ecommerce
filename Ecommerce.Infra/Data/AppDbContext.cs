using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Ecommerce.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Domain.Entities.ShoppingCart;
using Ecommerce.Domain.Entities.Orders;
using Ecommerce.Domain.Entities.Products;
using Ecommerce.Domain.Entities.Subcategories;
using Ecommerce.Domain.Entities.Categories;

namespace Ecommerce.Infra.Data
{
    public class AppDbContext : IdentityDbContext<CustomUser, IdentityRole<int>, int>
    {
        public DbSet<CustomerInfo> CustomerInfos { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSubcategory> ProductSubcategories { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomUser>()
            .HasOne(u => u.CustomerInfo)
            .WithOne(c => c.User)
            .HasForeignKey<CustomerInfo>(c => c.UserId);

            modelBuilder.Entity<Address>()
                .HasOne(ci => ci.CustomerInfo)
                .WithOne(a => a.Address)
                .HasForeignKey<CustomerInfo>(a => a.AddressId);

            modelBuilder.Entity<Order>()
                .HasOne(ps => ps.User)
                .WithMany(s => s.Orders)
                .HasForeignKey(ps => ps.UserId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(ps => ps.Order)
                .WithMany(s => s.OrderItems)
                .HasForeignKey(ps => ps.OrderId);

            modelBuilder.Entity<StatusHistory>()
                .HasOne(ps => ps.Order)
                .WithMany(s => s.StatusHistory)
                .HasForeignKey(ps => ps.OrderId);

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

            modelBuilder.Entity<CartItem>()
                .HasOne(ps => ps.Cart)
                .WithMany(s => s.Items)
                .HasForeignKey(ps => ps.CartId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ps => ps.Cart)
                .WithMany(s => s.Items)
                .HasForeignKey(ps => ps.CartId);

            modelBuilder.Entity<ProductSubcategory>()
                .HasKey(ps => new { ps.ProductId, ps.SubcategoryId });


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int>
            {
                Id = 99999,
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int>
            {
                Id = 88888,
                Name = "user",
                NormalizedName = "USER"
            });
        }
    }
}
