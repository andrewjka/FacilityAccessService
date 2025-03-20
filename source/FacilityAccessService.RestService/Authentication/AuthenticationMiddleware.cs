#region

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

#endregion

namespace FacilityAccessService.RestService.Authentication
{
    public class AuthenticationMiddleware
    {
        private readonly Dictionary<Endpoint, bool> _isEndpointAllowAnonymous;
        private readonly RequestDelegate _next;

        private readonly IUserSessionService _userSessionService;

        private readonly ITerminalSessionService _terminalSessionService;


        public AuthenticationMiddleware(
            IUserSessionService userSessionService,
            ITerminalSessionService terminalSessionService,
            RequestDelegate next
        )
        {
            _next = next;
            _userSessionService = userSessionService;
            _terminalSessionService = terminalSessionService;

            _isEndpointAllowAnonymous = new Dictionary<Endpoint, bool>();
        }


        public async Task InvokeAsync(HttpContext context)
        {
            bool isAllowAnonymous = CheckAllowAnonymous(context.GetEndpoint());

            string sessionToken = context.Request.GetSessionToken();
            string terminalSessionToken = context.Request.GetTerminalSessionToken();

            // If the session header is found, get the user
            if (string.IsNullOrEmpty(sessionToken) is false)
            {
                User user = await _userSessionService.ValidateTokenAsync(sessionToken);

                if (user is null)
                    throw new AuthenticationException(
                        $"The '{HttpRequestAuthentication.SessionTokenKey}' isn't valid."
                    );

                context.SetUser(user);
            }
            // If the terminal session header is found, get the terminal
            else if (string.IsNullOrEmpty(terminalSessionToken) is false)
            {
                Terminal terminal = await _terminalSessionService.ValidateTokenAsync(
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