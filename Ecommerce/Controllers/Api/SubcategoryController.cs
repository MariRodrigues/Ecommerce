using AutoMapper;
using Ecommerce.Application.Commands.Subcategories;
using Ecommerce.Domain.Entities.Subcategories;
using Ecommerce.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Ecommerce.Controllers.Api
{
    [ApiController]
    [Route("[controller]")]
    public class SubcategoryController : ControllerBase
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IMapper _mapper;

        public SubcategoryController(ISubcategoryRepository subcategoryRepository, IMapper mapper)
        {
            _subcategoryRepository = subcategoryRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra nova subcategoria",
                          OperationId = "Post")]
        [ProducesResponseType(201)]
        public IActionResult CreateSubcategory([FromServices] IMediator mediator, [FromBody] CreateSubcategoryCommand request)
        {
            var response = mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Buscar todas as subcategorias",
                          OperationId = "Get")]
        [ProducesResponseType(200)]
        public IActionResult GetAllSubcategories()
        {
            var response = _subcategoryRepository.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Buscar subcategoria por Id",
                          OperationId = "Get")]
        [ProducesResponseType(200)]
        public IActionResult GetCategoryById(int id)
        {
            var subcategoryViewModel = _mapper.Map<SubcategoryViewModel>(_subcategoryRepository.GetById(id));
            return Ok(subcategoryViewModel);
        }
    }
}
