using Microsoft.AspNetCore.Builder;
using RestService.Authentication;

namespace Application.DependencyInjection.RestService;

public static class RestServiceMiddlewaresExtension
{
    public static void AddRestServiceMiddlewares(this WebApplication app)
    {
        // Middlewares
        app.UseMiddleware<AuthenticationMiddleware>();

        // Add endpoints for controllers
        app.MapControllers();
    }
}