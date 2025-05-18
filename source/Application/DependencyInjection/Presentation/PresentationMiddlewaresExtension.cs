using Microsoft.AspNetCore.Builder;
using Presentation.Authentication;
using Presentation.GlobalErrorHandling;

namespace Application.DependencyInjection.Presentation;

public static class PresentationMiddlewaresExtension
{
    public static void AddPresentationMiddlewares(this WebApplication app)
    {
        // Middlewares
        app.UseMiddleware<GlobalErrorHandlingMiddleware>();
        
        app.UseMiddleware<AuthenticationMiddleware>();

        // Add endpoints for controllers
        app.MapControllers();
    }
}