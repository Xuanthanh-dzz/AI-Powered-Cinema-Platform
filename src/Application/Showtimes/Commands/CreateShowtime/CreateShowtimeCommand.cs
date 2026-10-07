using MediatR;

namespace CinemaPlatform.Application.Showtimes.Commands.CreateShowtime;

public record CreateShowtimeCommand(
    Guid MovieId,
    Guid AuditoriumId,
    DateTime StartTime,
    decimal BasePrice
) : IRequest<Guid>;
