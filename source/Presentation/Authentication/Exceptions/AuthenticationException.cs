#region

using System;
using Presentation.Common.Exceptions;

#endregion

namespace Presentation.Authentication.Exceptions;

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