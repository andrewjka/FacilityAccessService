using System;

namespace Domain.UserScope.Exceptions;

public class SuchUserAlreadyRegisteredException : Exception
{
    public SuchUserAlreadyRegisteredException()
    {
    }

    public SuchUserAlreadyRegisteredException(string message) : base(message)
    {
    }

    public SuchUserAlreadyRegisteredException(string message, Exception inner) : base(message, inner)
    {
    }
}