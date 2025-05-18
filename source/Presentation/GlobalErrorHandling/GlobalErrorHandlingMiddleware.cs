#region

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

#endregion

namespace Presentation.GlobalErrorHandling;

public class GlobalErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;


    public GlobalErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }


    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await WriteErrorResponse(context, 400, exception);
        }
    }

    private static async Task WriteErrorResponse(HttpContext context, int statusCode, object error)
    {
        var settings = new JsonSerializerSettings 
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(), // camelCase
            Formatting = Formatting.Indented, // Читаемый JSON
            NullValueHandling = NullValueHandling.Ignore // Игнорировать null-значения
        };
        
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(JsonConvert.SerializeObject(error, settings));
    }
}

public static class GlobalErrorHandlingMiddlewareExtension
{
    public static void UseGlobalErrorHandlingMiddleware(this WebApplication webApplication)
    {
        webApplication.UseMiddleware<GlobalErrorHandlingMiddleware>();
    }
}