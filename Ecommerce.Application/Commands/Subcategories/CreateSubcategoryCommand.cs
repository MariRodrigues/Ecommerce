using Ecommerce.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Commands.Subcategories
{
    public class CreateSubcategoryCommand : IRequest<ResponseApi>
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
