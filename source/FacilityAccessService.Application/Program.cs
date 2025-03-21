using FacilityAccessService.Application.DependencyInjection.BusinessVL;
using FacilityAccessService.Application.DependencyInjection.Domain;
using FacilityAccessService.Application.DependencyInjection.DomainSecure;
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


            // Modules injection section
            
            builder.AddBusinessVLModule();

            builder.AddPersistenceModule("");

            builder.AddMessagingClientModule("");

            builder.AddDomainModule();

            builder.AddDomainSecureModule();

            builder.AddRestServiceModuleExtension();


            WebApplication app = builder.Build();


            // Middlewares top level injection section


            app.Run();
        }
    }
}