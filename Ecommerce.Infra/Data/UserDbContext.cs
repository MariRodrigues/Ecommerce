using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Ecommerce.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infra.Data
{
    public class UserDbContext : IdentityDbContext<CustomUser, IdentityRole<int>, int>
    {
        public DbSet<CustomerInfo> CustomerInfos { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> opt) : base(opt)
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
