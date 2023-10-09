using AutoMapper;
using Ecommerce.Application.Commands.Category;
using Ecommerce.Domain.Entities.Categories;
using Ecommerce.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Ecommerce.Controllers.Api
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra nova categoria",
                          OperationId = "Post")]
        [ProducesResponseType(201)]
        public IActionResult CreateCategory([FromServices] IMediator mediator, [FromBody] CreateCategoryCommand request)
        {
            var response = mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Buscar todas as categorias",
                          OperationId = "Get")]
        [ProducesResponseType(200)]
        public IActionResult GetAllCategories()
        {
            var response = _categoryRepository.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Buscar categoria por Id",
                          OperationId = "Get")]
        [ProducesResponseType(200)]
        public IActionResult GetCategoryById(int id)
        {
            var categoryViewModel = _mapper.Map<CategoryViewModel>(_categoryRepository.GetById(id));
            return Ok(categoryViewModel);
        }
    }
}
