using CinemaPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaPlatform.Infrastructure.Persistence;

public class CinemaDbContext : DbContext
{
    public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Showtime> Showtimes => Set<Showtime>();
    public DbSet<Seat> Seats => Set<Seat>();
    public DbSet<Booking> Bookings => Set<Booking>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Nạp toàn bộ IEntityTypeConfiguration trong assembly này,
        // tránh phải liệt kê tay từng entity khi thêm bảng mới.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CinemaDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
