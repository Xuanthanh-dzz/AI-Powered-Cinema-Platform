using CinemaPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaPlatform.Infrastructure.Persistence.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");
        builder.HasKey(m => m.Id);

        // MaxLength khớp đúng với CreateMovieCommandValidator để tầng DB
        // không bao giờ chặt hơn hoặc lỏng hơn tầng validation của Application.
        builder.Property(m => m.Title).IsRequired().HasMaxLength(200);
        builder.Property(m => m.Genre).IsRequired().HasMaxLength(100);
        builder.Property(m => m.Description).IsRequired().HasMaxLength(2000);
        builder.Property(m => m.TrailerUrl).HasMaxLength(500);
        builder.Property(m => m.PosterUrl).HasMaxLength(500);

        // Tra cứu phim theo tên là truy vấn phổ biến của trang danh sách phim.
        builder.HasIndex(m => m.Title);
    }
}
