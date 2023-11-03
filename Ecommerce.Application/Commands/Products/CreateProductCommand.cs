using Ecommerce.Application.Response;
using Ecommerce.Domain.Entities.Products;
using MediatR;
using System.Collections.Generic;
using System;

namespace Ecommerce.Application.Commands.Products
{
    public class CreateProductCommand : IRequest<ResponseApi>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Height { get; set; }
        public string Color { get; set; }
        public int Size { get; set; }
        public double Width { get; set; }
        public double Weight { get; set; }
        public double Value { get; set; }
        public int SubcategoryId { get; set; }
        public List<ProductImagesCommand> Images { get; set; } = null;
    }

    public class ProductImagesCommand
    {
        public string Url { get; set; }
    }
}
