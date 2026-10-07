using CinemaPlatform.Application.Showtimes.Commands.CreateShowtime;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CinemaPlatform.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShowtimesController : ControllerBase
{
    private readonly ISender _sender;

    public ShowtimesController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>Tạo suất chiếu mới.</summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(
        [FromBody] CreateShowtimeCommand command,
        CancellationToken cancellationToken)
    {
        var id = await _sender.Send(command, cancellationToken);

        return Created($"/api/showtimes/{id}", new { id });
    }
}
