using Ecommerce.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Queries
{
    public interface ICustomerQueries
    {
        Task<IEnumerable<CustomerViewModel>> GetUsers();
        Task<CustomerViewModel> GetUserById(int userId);
    }
}
