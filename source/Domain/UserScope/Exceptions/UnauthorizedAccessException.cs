#region

using System;
using Domain.CommonScope.Exceptions;

#endregion

namespace Domain.UserScope.Exceptions;

public class UnauthorizedAccessException : DomainException
{
    public UnauthorizedAccessException()
    {
    }

    public UnauthorizedAccessException(string message) : base(message)
    {
    }

    public UnauthorizedAccessException(string message, Exception inner) : base(message, inner)
    {
    }
}