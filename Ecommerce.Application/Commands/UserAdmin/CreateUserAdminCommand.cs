using Ecommerce.Application.Response;
using Ecommerce.Domain.Entities.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Commands.UserAdmin
{
    public class CreateUserAdminCommand : IRequest<ResponseApi>
    {
        [Required]
        public string Name { get; set; }      
        public string PhoneNumber { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As senhas não conferem.")]
        public string Repassword { get; set; }
    }
}
