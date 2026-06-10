using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartSpaces.Application.Features.Spaces.Commands.CreateSpace;

namespace SmartSpaces.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpacesController : ControllerBase
{
    private readonly IMediator _mediator;

    public SpacesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSpaceCommand command)
    {
        var spaceId = await _mediator.Send(command);
        return CreatedAtAction(nameof(Create), new { id = spaceId }, command);
    }
}