using Ecommerce.Application.Commands.Products;
using Ecommerce.Application.Response;
using Ecommerce.Domain;
using Ecommerce.Domain.Entities.Products;
using Ecommerce.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Application.Handlers.Products
{
    public class ProductHandler : IProductHandler
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductSubcategoryRepository _productSubcategoryRepository;
        private readonly IProductImagesRepository _productImagesRepository;
        private readonly IProductSizesRepository _productSizesRepository;
        private readonly IUnitOfWork _uow;

        public ProductHandler(IProductRepository productRepository, IUnitOfWork uow, IProductSubcategoryRepository productSubcategoryRepository, IProductImagesRepository productImagesRepository, IProductSizesRepository productSizesRepository)
        {
            _productRepository = productRepository;
            _uow = uow;
            _productSubcategoryRepository = productSubcategoryRepository;
            _productImagesRepository = productImagesRepository;
            _productSizesRepository = productSizesRepository;
        }

        public async Task<ResponseApi> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product newProduct = new(request.Name, request.Description, request.Value, request.Quantity);

            using var scope = _uow.BeginTransaction();
           
            try
            {
                // Cadastra o produto
                var product = _productRepository.Include(newProduct);

                // Cadastra a relação de produto e subcategoria
                _productSubcategoryRepository.Include(new ProductSubcategory(product.Id, request.SubcategoryId));

                // Cadastra os tamanhos
                if (request.Sizes.Count > 0)
                {
                    product.Quantity = request.Sizes.Sum(size => size.Quantity);

                    var listSizes = await GenerateListSizes(request.Sizes, product.Id);
                    _productSizesRepository.Include(listSizes);
                }

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

        private async Task<List<ProductSize>> GenerateListSizes(List<ProductSizeCommand> sizes, int id)
        {
            List<ProductSize> sizesList = new();

            foreach (var size in sizes)
            {
                var newSize = new ProductSize()
                {
                    ProductId = id,
                    Quantity = size.Quantity,
                    Size = size.Size
                };
                sizesList.Add(newSize);
            }

            return sizesList;
        }

        private async Task<List<ProductImages>> GenerateListImages(List<string> imagesList, int productId)
        {
            List<ProductImages> list = new();

            foreach(var image in imagesList)
            {
                var newImage = new ProductImages()
                {
                    Url = image,
                    ProductId = productId
                };
                list.Add(newImage);
            }

            return list;
        }
    }
}
