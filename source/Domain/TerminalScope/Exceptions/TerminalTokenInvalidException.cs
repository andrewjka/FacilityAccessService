#region

using System;
using Domain.CommonScope.Exceptions;

#endregion

namespace Domain.TerminalScope.Exceptions;

public class TerminalTokenInvalidException : DomainException
{
    public TerminalTokenInvalidException()
    {
    }

    public TerminalTokenInvalidException(string message) : base(message)
    {
    }

    public TerminalTokenInvalidException(string message, Exception inner) : base(message, inner)
    {
    }
}