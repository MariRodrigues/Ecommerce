using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infra.Data
{
    public class UserDbContext : IdentityDbContext<CustomUser, IdentityRole<int>, int>
    {
        public UserDbContext(DbContextOptions<UserDbContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
