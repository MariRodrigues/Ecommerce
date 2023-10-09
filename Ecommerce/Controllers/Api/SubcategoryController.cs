using AutoMapper;
using Ecommerce.Application.Commands.Category;
using Ecommerce.Application.Commands.Subcategories;
using Ecommerce.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.JsonPatch.Operations;
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
    }
}
