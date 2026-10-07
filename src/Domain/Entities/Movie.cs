namespace CinemaPlatform.Domain.Entities;

public class Movie
{
    //id phim
    public Guid Id {get; set; }
    //Tên phim
    public string Title {get; set; } = string.Empty;
    //Thể loại phim
    public string Genre {get; set; } = string.Empty;
    //THời lượng
    public int DurationInMinutes {get; set; }
    //Ngày phát hành
    public DateTime ReleaseDate {get; set; }
    //Giới thiệu
    public string Description {get; set; } = string.Empty;
    //Link Trailer
    public string? TrailerUrl {get; set; }
    //Poster
    public string? PosterUrl {get; set; }
}