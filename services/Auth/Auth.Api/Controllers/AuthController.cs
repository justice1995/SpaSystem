using Auth.Api.Common;
using Auth.Application.Features.Auths.Login;
using Auth.Application.Features.Users.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);
            // Implement login logic here, e.g., send a LoginCommand to the mediator
            return result.ToActionResult();
        }
    }
}
