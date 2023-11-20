using Ecommerce.Domain.Entities.Orders;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Ecommerce.Domain.Entities.Users
{
    public class CustomUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public virtual CustomerInfo CustomerInfo { get; set; }
        public int CustomerInfoId { get; set; }
        public List<Order> Orders { get; set; }

        public CustomUser(string name, string email, string username, string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            Name = name;
            Email = email;
            UserName = username;
            Status = true;
            CreatedOn = DateTime.Now;
        }

        public CustomUser()
        {
        }
    }
}
