#region

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using FacilityAccessService.Business.CommonScope.Services;
using FacilityAccessService.Business.TerminalScope.Models;
using FacilityAccessService.Business.TerminalScope.ValueObjects;
using FacilityAccessService.Business.UserScope.Models;
using FacilityAccessService.RestService.Authentication.Attributes;
using FacilityAccessService.RestService.Authentication.Context;
using FacilityAccessService.RestService.Authentication.Exceptions;
using FacilityAccessService.RestService.Common.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace FacilityAccessService.RestService.Authentication
{
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
            await using AsyncServiceScope scope = _scopeFactory.CreateAsyncScope();

            IUserSessionService userSessionService = scope.ServiceProvider
                .GetService<IUserSessionService>();

            ITerminalSessionService terminalSessionService = scope.ServiceProvider
                .GetService<ITerminalSessionService>();

            Endpoint endpoint = context.GetEndpoint();

            if (endpoint is null)
            {
                await _next.Invoke(context);

                return;
            }

            bool isAllowAnonymous = CheckAllowAnonymous(endpoint);

            string sessionToken = context.Request.GetSessionToken();
            string terminalSessionToken = context.Request.GetTerminalSessionToken();

            // If the session header is found, get the user
            if (string.IsNullOrEmpty(sessionToken) is false)
            {
                User user = await userSessionService.ValidateTokenAsync(sessionToken);

                if (user is null)
                    throw new AuthenticationException(
                        $"The '{HttpRequestAuthentication.SessionTokenKey}' isn't valid."
                    );

                context.SetUser(user);
            }
            // If the terminal session header is found, get the terminal
            else if (string.IsNullOrEmpty(terminalSessionToken) is false)
            {
                Terminal terminal = await terminalSessionService.ValidateTokenAsync(
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
            bool isAllowAnonymous = false;

            bool isDefined = _isEndpointAllowAnonymous.TryGetValue(endpoint, out isAllowAnonymous);

            if (isDefined is false)
            {
                ControllerActionDescriptor descriptor = endpoint.Metadata.GetMetadata<ControllerActionDescriptor>();

                MethodInfo action = descriptor.MethodInfo;

                AllowAnonymousAttribute allowAnonymous = action.GetCustomAttribute<AllowAnonymousAttribute>();

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
}