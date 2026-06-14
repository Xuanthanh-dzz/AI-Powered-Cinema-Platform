namespace cinemaPlatform.domain.Entities;

public class Seat
{
    public Guid Id {get; set; }
    //Id showtime
    public Guid ShowtimeId {get; set; }
    public Showtime Showtime { get; set; } = null!;
    //Hàng ghế
    public string Row {get; set; } = string.Empty;
    //Số ghế trong hàng
    public int Number {get; set; }
    //Xác định ghế đã đặt chưa
    public bool IsBooked {get; set; }
}