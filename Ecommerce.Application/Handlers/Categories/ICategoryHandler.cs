using Ecommerce.Application.Commands.Category;
using Ecommerce.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Handlers.Categories
{
    public interface ICategoryHandler :
        IRequestHandler<CreateCategoryCommand, ResponseApi>
    {
    }
}
