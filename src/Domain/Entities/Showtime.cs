namespace cinemaPlatform.domain.Entities;

public class Showtime
{
    public Guid Id {get; set; }
    //id phim
    public Guid MovieId {get; set; }
    //Khoá ngoại Auditorium
    public Guid AuditoriumId {get; set; }
    //giờ bắt đầu chiếu
    public DateTime StartTime {get; set; }
    //Giá vé cơ bản
    public decimal BasePrice {get; set; }
}