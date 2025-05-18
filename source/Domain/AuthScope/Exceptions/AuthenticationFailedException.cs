using System;

namespace Domain.AuthScope.Exceptions;

public class AuthenticationFailedException : Exception
{
    public AuthenticationFailedException()
    {
    }

    public AuthenticationFailedException(string message) : base(message)
    {
    }

    public AuthenticationFailedException(string message, Exception inner) : base(message, inner)
    {
    }
}