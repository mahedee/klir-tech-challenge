using Klir.TechChallenge.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Klir.TechChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllProductQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
