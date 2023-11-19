using Ecommerce.Application.Commands.Customers;
using Ecommerce.Application.Commands.UserAdmin;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Ecommerce.Controllers.Auth
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra usuário admin do sistema",
                          OperationId = "Post")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreateCustomerUser([FromServices] IMediator mediator, [FromBody] CreateUserAdminCommand request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
