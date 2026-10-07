using CinemaPlatform.Domain.Entities;
using CinemaPlatform.Domain.Interfaces;
using MediatR;

namespace CinemaPlatform.Application.Showtimes.Commands.CreateShowtime;

public class CreateShowtimeCommandHandler : IRequestHandler<CreateShowtimeCommand, Guid>
{
    private readonly IRepository<Showtime> _repository;

    public CreateShowtimeCommandHandler(IRepository<Showtime> repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateShowtimeCommand request, CancellationToken cancellationToken)
    {
        var showtime = new Showtime
        {
            Id = Guid.NewGuid(),
            MovieId = request.MovieId,
            AuditoriumId = request.AuditoriumId,
            StartTime = request.StartTime,
            BasePrice = request.BasePrice
        };

        await _repository.AddAsync(showtime, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return showtime.Id;
    }
}
