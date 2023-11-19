using Ecommerce.Application.Response;
using Ecommerce.Domain.Entities.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Commands.Customers
{
    public class CreateCustomerInfoCommand : IRequest<ResponseApi>
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public Sexo Gender { get; set; }
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
