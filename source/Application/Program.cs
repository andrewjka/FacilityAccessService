using Application.DependencyInjection.BusinessVL;
using Application.DependencyInjection.Domain;
using Application.DependencyInjection.DomainSecure;
using Application.DependencyInjection.Messaging;
using Application.DependencyInjection.Persistence;
using Application.DependencyInjection.RestService;
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


        // Modules injection section

        builder.AddBusinessVLModule();

        builder.AddDomainModule();

        builder.AddPersistenceModule(connectMySQLString);

        builder.AddMessagingModule(connectRabbitMQString);

        builder.AddDomainSecureModule();

        builder.AddRestServiceModuleExtension();


        var app = builder.Build();


        // Middlewares top level injection section

        app.AddRestServiceMiddlewares();

        app.Run();
    }
}