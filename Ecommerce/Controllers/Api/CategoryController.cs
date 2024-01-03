using AutoMapper;
using Ecommerce.Application.Commands.Category;
using Ecommerce.Domain.Entities.Categories;
using Ecommerce.Domain.Queries;
using Ecommerce.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Ecommerce.Controllers.Api
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryQueries _categoriyQueries;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper, ICategoryQueries categoriyQueries)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoriyQueries = categoriyQueries;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra nova categoria",
                          OperationId = "Post")]
        [ProducesResponseType(201)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreateCategory([FromServices] IMediator mediator, [FromBody] CreateCategoryCommand request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Buscar todas as categorias com subcategorias",
                          OperationId = "Get")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAllCategories()
        {
            var response = await _categoriyQueries.GetCategoryWithSubcategories();
            return Ok(response);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Buscar categoria por Id",
                          OperationId = "Get")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var categoryViewModel = _mapper.Map<CategoryViewModel>(_categoryRepository.GetById(id));
            return Ok(categoryViewModel);
        }

        [HttpGet("/subcategories/products")]
        [SwaggerOperation(Summary = "Buscar todas categorias com subcategorias e produtos",
                          OperationId = "Get")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetCategoriesWithProducts()
        {
            var response = await _categoriyQueries.GetCategoryWithProducts();
            return Ok(response);
        }
    }
}
