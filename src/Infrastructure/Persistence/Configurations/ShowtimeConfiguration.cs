using CinemaPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaPlatform.Infrastructure.Persistence.Configurations;

public class ShowtimeConfiguration : IEntityTypeConfiguration<Showtime>
{
    public void Configure(EntityTypeBuilder<Showtime> builder)
    {
        builder.ToTable("Showtimes");
        builder.HasKey(s => s.Id);

        // decimal(18,2) — đủ chứa tiền VND, không dùng float/double cho tiền tệ.
        builder.Property(s => s.BasePrice).HasPrecision(18, 2);

        // Restrict: không cho xoá phim khi vẫn còn suất chiếu tham chiếu tới.
        builder.HasOne<Movie>()
            .WithMany()
            .HasForeignKey(s => s.MovieId)
            .OnDelete(DeleteBehavior.Restrict);

        // Lịch chiếu theo phim và theo ngày là 2 truy vấn chính của màn hình đặt vé.
        builder.HasIndex(s => new { s.MovieId, s.StartTime });

        // AuditoriumId chưa có FK vì entity Auditorium chưa tồn tại trong Domain.
        // Khi thêm Auditorium thì bổ sung HasOne<Auditorium>() ở đây.
    }
}
