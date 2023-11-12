using Microsoft.AspNetCore.Identity;
using System;

namespace Ecommerce.Domain.Entities.Users
{
    public class CustomUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
