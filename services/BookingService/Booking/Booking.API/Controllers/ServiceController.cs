using Asp.Versioning;
using BookingSystem.API.Common;
using BookingSystem.Application.Features.Services.Command.CreateService;
using BookingSystem.Application.Features.Services.Command.DeleteService;
using BookingSystem.Application.Features.Services.Command.UpdateService;
using BookingSystem.Application.Features.Services.DTOs;
using BookingSystem.Application.Features.Services.Queries.GetAllServices;
using BookingSystem.Application.Features.Services.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/service")]
    [ApiController]
    public class ServiceController1 : ControllerBase
    {
        private readonly IMediator _mediator;
        public ServiceController1(IMediator mediator)
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
            return result.ToActionResult();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteService(Guid id)
        {
            var result = await _mediator.Send(new DeleteServiceCommand { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// Get Service By Id
        /// </summary>
        /// <remarks>
        /// Get Service By Id 1
        /// </remarks>
        /// <param name="id">Service identifier</param>
        /// <response code="200">Success</response>
        /// <response code="404">Service not found</response>
        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(APISuccessReponse<ServiceDto>), 200)]
        [ProducesResponseType(typeof(APIErrorResponse), 404)]
        [ProducesResponseType(typeof(APIErrorResponse), 400)]
        public async Task<IActionResult> GetServiceById(Guid id)
        {
            var result = await _mediator.Send(new GetByIdQuery { Id = id });
            return result.ToActionResult(); ;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            var result = await _mediator.Send(new GetAllServicesQuery());
            return Ok(result);
        }

    }
}
