using Klir.TechChallenge.Application.Commands;
using Klir.TechChallenge.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Klir.TechChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetUsersCart")]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetUsersCartQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost("AddItemToCart")]
        public async Task<IActionResult> AddItemToCartAsync([FromBody] CartItemAddCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        // PUT api/<CartController>/5
        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> Put(CartItemUpdateCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        // DELETE api/<CartController>/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new CartItemDeleteCommand(id)));
        }
    }
}

