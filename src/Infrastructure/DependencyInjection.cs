using CinemaPlatform.Domain.Interfaces;
using CinemaPlatform.Infrastructure.Persistence;
using CinemaPlatform.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaPlatform.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("CinemaDb")
            ?? throw new InvalidOperationException(
                "Không tìm thấy connection string 'CinemaDb' trong appsettings.json");

        services.AddDbContext<CinemaDbContext>(options =>
            options.UseSqlServer(connectionString));

        // Đăng ký generic repository: mọi IRepository<Movie>, IRepository<Seat>...
        // đều tự resolve về Repository<T> tương ứng, không cần khai báo từng loại.
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }
}
