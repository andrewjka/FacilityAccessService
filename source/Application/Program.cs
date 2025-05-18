using Application.DependencyInjection.BusinessVL;
using Application.DependencyInjection.Business;
using Application.DependencyInjection.BusinessSecure;
using Application.DependencyInjection.Cache;
using Application.DependencyInjection.Messaging;
using Application.DependencyInjection.Persistence;
using Application.DependencyInjection.Presentation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Application;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // These settings verify that all dependencies are present for any service to be created.
        builder.Host.UseDefaultServiceProvider(options =>
        {
            options.ValidateScopes = true;
            options.ValidateOnBuild = true;
        });

        // Configuration section

        var connectMySQLString = builder.Configuration["Databases:MySQL"];

        var connectRabbitMQString = builder.Configuration["Messaging:RabbitMQ"];
        
        var connectRedisString = builder.Configuration["Caching:Redis"];


        // Modules injection section
        
        builder.AddPersistenceModule(connectMySQLString);
        
        builder.AddCacheModuleExtension(connectRedisString);
        
        builder.AddMessagingModule(connectRabbitMQString);

        builder.AddBusinessVLModule();

        builder.AddBusinessModule();

        builder.AddBusinessSecureModule();

        builder.AddPresentationModuleExtension();


        var app = builder.Build();


        // Middlewares top level injection section

        app.AddPresentationMiddlewares();

        app.Run();
    }
}