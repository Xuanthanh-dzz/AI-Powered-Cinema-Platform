using MediatR;

namespace cinemaPlatform.Application.Movies.Commands.CreateMovie;

public record CreateMovieCommand(
    string Title,
    string Genre,
    int DurationInMinutes,
    DateTime ReleaseDate,
    string Description,
    string? TrailerUrl,
    string? PosterUrl
) : IRequest<Guid>;
