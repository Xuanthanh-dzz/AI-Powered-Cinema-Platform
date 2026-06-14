namespace cinemaPlatform.domain.Entities;

public class Booking
{
    public Guid Id { get; set; }
    //Khoá ngoại đến Showtime
    public Guid ShowtimeId { get; set; } 
    //Id user
    public string UserId { get; set; } = string.Empty;
    //Thời gian đặt vé
    public DateTime BookingTime { get; set; }
    //Tổng tiền
    public decimal TotalPrice { get; set; }
    public BookingStatus Status { get; set; }
    public Showtime Showtime { get; set; } = null!;
}
public enum BookingStatus
{
    Pending,
    Confirmed,
    Cancelled
}