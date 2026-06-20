using MediatR;

namespace cinemaPlatform.Application.Showtimes.Commands.createShowtime;

public record createShowtime (
    Guid MovieId,
    Guid AuditoriumId,
    DateTime StartTime,
    decimal BasePrice
) : IRequest<Guid>;