using Ecommerce.Application.Commands.Category;
using Ecommerce.Application.Commands.Products;
using Ecommerce.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Handlers.Products
{
    public interface IProductHandler :
        IRequestHandler<CreateProductCommand, ResponseApi>
    {
    }
}
