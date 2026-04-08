using Booking.Application.Features.Services.Command.CreateService;
using Booking.Application.Features.Services.Command.DeleteService;
using Booking.Application.Features.Services.Command.UpdateService;
using Booking.Application.Features.Services.Queries.GetAllServices;
using Booking.Application.Features.Services.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService([FromBody] UpdateServiceCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteService(Guid id)
        {
            var result = await _mediator.Send(new DeleteServiceCommand { Id = id });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(Guid id)
        {
            var result = await _mediator.Send(new GetByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            var result = await _mediator.Send(new GetAllServicesQuery());
            return Ok(result);
        }
        
    }
}
