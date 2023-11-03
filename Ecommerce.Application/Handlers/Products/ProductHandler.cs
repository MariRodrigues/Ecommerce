using Ecommerce.Application.Commands.Products;
using Ecommerce.Application.Response;
using Ecommerce.Domain;
using Ecommerce.Domain.Entities.Products;
using Ecommerce.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Application.Handlers.Products
{
    public class ProductHandler : IProductHandler
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductSubcategoryRepository _productSubcategoryRepository;
        private readonly IProductImagesRepository _productImagesRepository;
        private readonly IUnitOfWork _uow;

        public ProductHandler(IProductRepository productRepository, IUnitOfWork uow, IProductSubcategoryRepository productSubcategoryRepository, IProductImagesRepository productImagesRepository)
        {
            _productRepository = productRepository;
            _uow = uow;
            _productSubcategoryRepository = productSubcategoryRepository;
            _productImagesRepository = productImagesRepository;
        }

        public async Task<ResponseApi> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product newProduct = new()
            {
                Name = request.Name,
                Height = request.Height,
                Size = request.Size,
                Weight = request.Weight,
                Description = request.Description,
                Color = request.Color,
                Value = request.Value,
                Width = request.Width,
                Status = true,
                UpdatedOn = null,
                CreatedOn = DateTime.Now
            };

            using var scope = _uow.BeginTransaction();
           
            try
            {
                // Cadastra o produto
                var product = _productRepository.Include(newProduct);

                // Cadastra a relação de produto e subcategoria
                _productSubcategoryRepository.Include(new ProductSubcategory(product.Id, request.SubcategoryId));

                // Cadastra imagens
                if (request.Images!= null || request.Images?.Count > 0)
                {
                    var listImages = await GenerateListImages(request.Images, product.Id);
                    _productImagesRepository.Include(listImages);
                }
            }
            catch (Exception ex)
            {
                scope.RollbackTransaction();
                return new ResponseApi(false, "Não foi possível cadastrar a categoria: " + ex.Message);
            }

            scope.Commit();
            return new ResponseApi(true, "Produto cadastrado com sucesso. ");
        }

        private async Task<List<ProductImages>> GenerateListImages(List<ProductImagesCommand> imagesList, int productId)
        {
            List<ProductImages> list = new();

            foreach(var image in imagesList)
            {
                var newImage = new ProductImages()
                {
                    Url = image.Url,
                    ProductId = productId
                };
                list.Add(newImage);
            }

            return list;
        }
    }
}
