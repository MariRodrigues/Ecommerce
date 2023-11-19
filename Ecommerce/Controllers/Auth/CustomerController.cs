using Ecommerce.Application.Commands.Customers;
using Ecommerce.Domain.Queries;
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
        private readonly ICustomerQueries _customerQueries;

        public CustomerController(ICustomerQueries customerQueries)
        {
            _customerQueries = customerQueries;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra novo usuário cliente",
                          OperationId = "Post")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreateCustomerUser([FromServices] IMediator mediator, [FromBody] CreateUserCommand request)
        {
            var response = await mediator.Send(request);

            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response);
        }

        [HttpPost("infos")]
        [SwaggerOperation(Summary = "Cadastra informações adicionais do cliente",
                          OperationId = "Post")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreateCustomerInfosUser([FromServices] IMediator mediator, [FromBody] CreateCustomerInfoCommand request)
        {
            var response = await mediator.Send(request);

            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Buscar todos os usuários",
                          OperationId = "Get")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _customerQueries.GetUsers();
            return Ok(response);
        }

        [HttpGet("{userId}")]
        [SwaggerOperation(Summary = "Buscar usuário por Id",
                          OperationId = "Get")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetUsers(int userId)
        {
            var response = await _customerQueries.GetUserById(userId);

            if (response is null)
                return NotFound();

            return Ok(response);
        }
    }
}
