using Ecommerce.Application.Commands.Subcategories;
using Ecommerce.Application.Commands.UserAdmin;
using Ecommerce.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Handlers.UserAdmin
{
    public interface IUserAdminHandler :
        IRequestHandler<CreateUserAdminCommand, ResponseApi>
    {
    }
}
