using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using FacilityAccessService.Business.CommonScope.Services;
using FacilityAccessService.RestService.Authentication.Attributes;
using FacilityAccessService.RestService.Authentication.Context;
using FacilityAccessService.RestService.Authentication.Exceptions;
using FacilityAccessService.RestService.Common.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace FacilityAccessService.RestService.Authentication
{
    public class AuthenticationMiddleware
    {
        private readonly Dictionary<Endpoint, bool> _isEndpointAllowAnonymous;
        private readonly RequestDelegate _next;

        private readonly ISessionService _sessionService;


        public AuthenticationMiddleware(ISessionService sessionService, RequestDelegate next)
        {
            _next = next;
            _sessionService = sessionService;

            _isEndpointAllowAnonymous = new Dictionary<Endpoint, bool>();
        }


        public async Task InvokeAsync(HttpContext context)
        {
            var isAllowAnonymous = CheckAllowAnonymous(context.GetEndpoint());
            var sessionToken = context.Request.GetSessionToken();

            // If the session header is found, get the user
            if (string.IsNullOrEmpty(sessionToken) is false)
            {
                var (user, isValidate) = await _sessionService.ValidateTokenAsync(sessionToken);

                if (isValidate is false)
                    throw new AuthenticationException(
                        $"The '{HttpRequestAuthentication.SessionTokenKey}' isn't valid."
                    );

                context.SetUser(user);
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
}