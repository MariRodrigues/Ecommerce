using AutoMapper;
using Ecommerce.Application.Commands.Category;
using Ecommerce.Application.Commands.Products;
using Ecommerce.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Ecommerce.Controllers.Api
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra novo produto",
                          OperationId = "Post")]
        [ProducesResponseType(201)]
        public IActionResult CreateProduct([FromServices] IMediator mediator, [FromBody] CreateProductCommand request)
        {
            var response = mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Busca todos os produtos",
                          OperationId = "Get")]
        [ProducesResponseType(201)]
        public IActionResult GetAllProducts()
        {
            return Ok(_productRepository.GetAll());
        }
    }
}
