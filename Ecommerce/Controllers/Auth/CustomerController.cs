using Ecommerce.Application.Commands.Category;
using Ecommerce.Application.Commands.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Ecommerce.Controllers.Auth
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra novo usuário",
                          OperationId = "Post")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreateCustomerUser([FromServices] IMediator mediator, [FromBody] CreateUserCommand request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
