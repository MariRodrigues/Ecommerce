using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities.Users
{
    public class CustomerInfo
    {
        public int Id { get; set; }
        public virtual CustomUser User { get; set; }
        public int UserId { get; set; }
        public string CPF { get; set; }
        public Sexo Gender { get; set; }
    }

    public enum Sexo
    {
        Female = 1,
        Male = 2
    }
}
