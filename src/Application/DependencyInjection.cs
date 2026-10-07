using System.Reflection;
using CinemaPlatform.Application.Common.Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaPlatform.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(assembly);

            // Pipeline behavior chạy cho MỌI request theo đúng thứ tự đăng ký.
            // Thêm behavior mới (logging, performance) chỉ cần thêm 1 dòng ở đây.
            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        // Quét assembly tìm mọi AbstractValidator<T> và đăng ký vào DI.
        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}
