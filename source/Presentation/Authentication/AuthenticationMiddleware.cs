#region

using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Domain.CommonScope.Services;
using Domain.TerminalScope.ValueObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Authentication.Attributes;
using Presentation.Authentication.Context;
using Presentation.Authentication.Exceptions;
using Presentation.Common.Exceptions;

#endregion

namespace Presentation.Authentication;

public class AuthenticationMiddleware
{
    private readonly Dictionary<Endpoint, bool> _isEndpointAllowAnonymous;
    private readonly RequestDelegate _next;

    private readonly IServiceScopeFactory _scopeFactory;


    public AuthenticationMiddleware(IServiceScopeFactory scopeFactory, RequestDelegate next)
    {
        _next = next;
        _scopeFactory = scopeFactory;

        _isEndpointAllowAnonymous = new Dictionary<Endpoint, bool>();
    }


    public async Task InvokeAsync(HttpContext context)
    {
        await using var scope = _scopeFactory.CreateAsyncScope();

        var userSessionService = scope.ServiceProvider
            .GetService<IUserSessionService>();

        var terminalSessionService = scope.ServiceProvider
            .GetService<ITerminalSessionService>();

        var endpoint = context.GetEndpoint();

        if (endpoint is null)
        {
            await _next.Invoke(context);

            return;
        }

        var isAllowAnonymous = CheckAllowAnonymous(endpoint);

        var sessionToken = context.Request.GetSessionToken();
        var terminalSessionToken = context.Request.GetTerminalSessionToken();

        // If the session header is found, get the user
        if (string.IsNullOrEmpty(sessionToken) is false)
        {
            var user = await userSessionService.ValidateTokenAsync(sessionToken);

            if (user is null)
                throw new AuthenticationException(
                    $"The '{HttpRequestAuthentication.SessionTokenKey}' isn't valid."
                );

            context.SetUser(user);
        }
        // If the terminal session header is found, get the terminal
        else if (string.IsNullOrEmpty(terminalSessionToken) is false)
        {
            var terminal = await terminalSessionService.ValidateTokenAsync(
                TerminalToken.GetFromHex(terminalSessionToken)
            );

            if (terminal is null)
                throw new AuthenticationException(
                    $"The '{HttpRequestAuthentication.TerminalSessionTokenKey}' isn't valid."
                );

            context.SetTerminal(terminal);
        }
        // If authorization is required but there is no session token, we throw an error
        else if (isAllowAnonymous is false)
        {
            throw new HeaderHasNotFound(
                $"The required header '{nameof(HttpRequestAuthentication.SessionTokenKey)}' has not been found."
            );
        }


        await _next.Invoke(context);
    }

    private bool CheckAllowAnonymous(Endpoint endpoint)
    {
        var isAllowAnonymous = false;

        var isDefined = _isEndpointAllowAnonymous.TryGetValue(endpoint, out isAllowAnonymous);

        if (isDefined is false)
        {
            var descriptor = endpoint.Metadata.GetMetadata<ControllerActionDescriptor>();

            var action = descriptor.MethodInfo;

            var allowAnonymous = action.GetCustomAttribute<AllowAnonymousAttribute>();

            if (allowAnonymous is null)
                allowAnonymous = action.DeclaringType.GetCustomAttribute<AllowAnonymousAttribute>();

            _isEndpointAllowAnonymous[endpoint] = allowAnonymous is not null;
        }

        return isAllowAnonymous;
    }
}

public static class AuthenticationMiddlewareExtension
{
    public static void UseAuthenticationMiddleware(this WebApplication webApplication)
    {
        webApplication.UseMiddleware<AuthenticationMiddleware>();
    }
}