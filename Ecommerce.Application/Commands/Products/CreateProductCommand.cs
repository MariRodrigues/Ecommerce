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
        public double Value { get; set; }
        public int SubcategoryId { get; set; }
        public int Quantity { get; set; }
        public List<string> Images { get; set; } = new List<string>();
        public List<ProductSizeCommand> Sizes { get; set; } = new List<ProductSizeCommand>();
    }

    public class ProductImagesCommand
    {
        public string Url { get; set; }
    }

    public class ProductSizeCommand
    {
        public SizeEnum Size { get; set; }
        public int Quantity { get; set; }
    }
}
