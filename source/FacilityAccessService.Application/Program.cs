using FacilityAccessService.Application.DependencyInjection.BusinessVL;
using FacilityAccessService.Application.DependencyInjection.Domain;
using FacilityAccessService.Application.DependencyInjection.DomainSecure;
using FacilityAccessService.Application.DependencyInjection.GrpcClient;
using FacilityAccessService.Application.DependencyInjection.MessagingClient;
using FacilityAccessService.Application.DependencyInjection.Persistence;
using FacilityAccessService.Application.DependencyInjection.RestService;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace FacilityAccessService.Application
{
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

            string connectMySQLString = builder.Configuration["Databases:MySQL"];

            string connectRabbitMQString = builder.Configuration["Messaging:RabbitMQ"];


            // Modules injection section

            builder.AddBusinessVLModule();
            
            builder.AddDomainModule();

            builder.AddPersistenceModule(connectMySQLString);

            builder.AddMessagingClientModule(connectRabbitMQString);
            
            builder.AddGrpcClientModule();
            
            builder.AddDomainSecureModule();

            builder.AddRestServiceModuleExtension();


            WebApplication app = builder.Build();


            // Middlewares top level injection section

            app.AddRestServiceMiddlewares();
            
            app.Run();
        }
    }
}