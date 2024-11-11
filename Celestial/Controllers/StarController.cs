using Celestial.API.Domain.Commands.Requests;
using Celestial.API.Domain.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Celestial.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStar(int id)
        {
            var query = new GetStarQueryRequest(id);
            var response = await _mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStars()
        {
            var query = new GetAllStarsQueryRequest();
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStar([FromBody] CreateStarCommandRequest command)
        {
            var response = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetStar), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStar(int id, [FromBody] UpdateStarCommandRequest command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(command);

            if (response.Success)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStar(int id)
        {
            var command = new DeleteStarCommandRequest(id);
            var response = await _mediator.Send(command);

            if (response.IsSuccess)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
