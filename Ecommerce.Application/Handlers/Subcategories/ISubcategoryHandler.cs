using Ecommerce.Application.Commands.Category;
using Ecommerce.Application.Commands.Subcategories;
using Ecommerce.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Handlers.Subcategories
{
    public interface ISubcategoryHandler :
        IRequestHandler<CreateSubcategoryCommand, ResponseApi>
    {
    }
}
