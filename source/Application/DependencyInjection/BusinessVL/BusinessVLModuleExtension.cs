using Domain.Validation.UserScope.Models;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Application.DependencyInjection.BusinessVL;

public static class BusinessVLModuleExtension
{
    public static void AddBusinessVLModule(this IHostApplicationBuilder builder)
    {
        builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>(ServiceLifetime.Singleton);
    }
}