using CinemaPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaPlatform.Infrastructure.Persistence.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Bookings");
        builder.HasKey(b => b.Id);

        // UserId là định danh từ Identity Provider (Keycloak ở giai đoạn sau),
        // Domain không quản lý bảng user nên chỉ lưu chuỗi, không có FK.
        builder.Property(b => b.UserId).IsRequired().HasMaxLength(100);

        builder.Property(b => b.TotalPrice).HasPrecision(18, 2);

        // Lưu enum dạng chuỗi ("Confirmed") thay vì số (1) để đọc trực tiếp
        // trong DB hiểu ngay, và thêm/bớt giá trị enum không làm sai dữ liệu cũ.
        builder.Property(b => b.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        // Restrict: giữ lại lịch sử đặt vé, không cho xoá suất chiếu đã có người đặt.
        builder.HasOne(b => b.Showtime)
            .WithMany()
            .HasForeignKey(b => b.ShowtimeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Truy vấn "vé của tôi" và thống kê theo người dùng.
        builder.HasIndex(b => b.UserId);
    }
}
