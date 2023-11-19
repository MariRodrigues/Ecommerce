using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities.Users
{
    public class CustomerViewModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Gender { get; set; }
        public AddressViewModel Address { get; set; }
    }

    public class AddressViewModel
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CEP { get; set; }
        public string Country { get; set; }
        public string ReceiverName { get; set; }
        public string Observation { get; set; }
    }
}
