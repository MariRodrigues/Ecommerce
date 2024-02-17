using Ecommerce.Application.Commands.Products;
using Ecommerce.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> CreateProductAsync([FromServices] IMediator mediator, [FromBody] CreateProductCommand request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Busca todos os produtos",
                          OperationId = "Get")]
        [ProducesResponseType(201)]
        public IActionResult GetAllProducts(string? nome)
        {
            var response = _productRepository.GetAll(nome);

            return Ok(response);
        }
    }
}
