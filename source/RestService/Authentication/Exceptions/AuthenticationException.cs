#region

using System;
using RestService.Common.Exceptions;

#endregion

namespace RestService.Authentication.Exceptions;

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