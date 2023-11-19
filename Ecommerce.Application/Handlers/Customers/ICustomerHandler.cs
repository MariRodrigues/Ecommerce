using Ecommerce.Application.Commands.Customers;
using Ecommerce.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Handlers.Customers
{
    public interface ICustomerHandler :
        IRequestHandler<CreateUserCommand, ResponseApi>,
        IRequestHandler<CreateCustomerInfoCommand, ResponseApi>
    {
    }
}
