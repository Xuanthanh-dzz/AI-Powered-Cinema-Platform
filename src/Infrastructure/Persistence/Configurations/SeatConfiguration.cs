using CinemaPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaPlatform.Infrastructure.Persistence.Configurations;

public class SeatConfiguration : IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        builder.ToTable("Seats");
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Row).IsRequired().HasMaxLength(5);

        // Xoá suất chiếu thì xoá luôn ghế của suất đó — ghế vô nghĩa nếu không có suất chiếu.
        builder.HasOne(s => s.Showtime)
            .WithMany()
            .HasForeignKey(s => s.ShowtimeId)
            .OnDelete(DeleteBehavior.Cascade);

        // Chốt ở tầng DB: một suất chiếu không thể có 2 ghế trùng hàng + số.
        // Đây là lưới an toàn cuối cùng, tầng Application vẫn phải kiểm tra trước.
        builder.HasIndex(s => new { s.ShowtimeId, s.Row, s.Number }).IsUnique();
    }
}
