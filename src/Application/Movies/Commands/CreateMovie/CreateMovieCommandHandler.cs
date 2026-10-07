using CinemaPlatform.Domain.Entities;
using CinemaPlatform.Domain.Interfaces;
using MediatR;

namespace CinemaPlatform.Application.Movies.Commands.CreateMovie;

public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Guid>
{
    private readonly IRepository<Movie> _repository;

    public CreateMovieCommandHandler(IRepository<Movie> repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = new Movie
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Genre = request.Genre,
            DurationInMinutes = request.DurationInMinutes,
            ReleaseDate = request.ReleaseDate,
            Description = request.Description,
            TrailerUrl = request.TrailerUrl,
            PosterUrl = request.PosterUrl
        };

        await _repository.AddAsync(movie, cancellationToken);

        // AddAsync chỉ đánh dấu entity vào DbContext, chưa ghi xuống DB.
        // Thiếu SaveChangesAsync thì request trả về Id nhưng DB không có gì.
        await _repository.SaveChangesAsync(cancellationToken);

        return movie.Id;
    }
}
