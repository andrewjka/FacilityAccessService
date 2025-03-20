#region

using System;
using FacilityAccessService.RestService.Common.Exceptions;

#endregion

namespace FacilityAccessService.RestService.Authentication.Exceptions
{
    public class AuthenticationException : RestServiceException
    {
        public AuthenticationException()
        {
        }

        public AuthenticationException(string message) : base(message)
        {
        }

        public AuthenticationException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}