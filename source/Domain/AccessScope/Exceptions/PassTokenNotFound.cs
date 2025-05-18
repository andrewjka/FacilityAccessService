using System;

namespace Domain.AccessScope.Exceptions;

public class PassTokenNotFound : Exception
{
    public PassTokenNotFound()
    {
    }

    public PassTokenNotFound(string message) : base(message)
    {
    }

    public PassTokenNotFound(string message, Exception inner) : base(message, inner)
    {
    }
}