using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shared.Handlers;

namespace Shared.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IServiceCollection AddSharedExceptionHandling(this IServiceCollection services)
    {
        services.AddProblemDetails();
        services.AddExceptionHandler<GlobalExceptionHandler>();

        return services;
    }

    public static IApplicationBuilder UseSharedExceptionHandling(this IApplicationBuilder app)
    {
        return app.UseExceptionHandler();
    }
}
