using Microsoft.AspNetCore.Builder;

namespace FacilityAccessService.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            
            // Configuration section
            
            
            // Modules injection section
            
            
            WebApplication app = builder.Build();
            
            
            // Middlewares top level injection section
            
            
            app.Run();
        }
    }
}