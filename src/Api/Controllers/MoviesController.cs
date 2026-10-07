using CinemaPlatform.Application.Movies.Commands.CreateMovie;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CinemaPlatform.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    // Controller chỉ biết ISender, không biết Handler nào xử lý.
    // Đây là lợi ích chính của MediatR: thêm command mới không phải sửa controller cũ.
    private readonly ISender _sender;

    public MoviesController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>Tạo phim mới.</summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(
        [FromBody] CreateMovieCommand command,
        CancellationToken cancellationToken)
    {
        var id = await _sender.Send(command, cancellationToken);

        return Created($"/api/movies/{id}", new { id });
    }
}
