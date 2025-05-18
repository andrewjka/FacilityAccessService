#region

using System;
using Domain.CommonScope.Exceptions;

#endregion

namespace Domain.TerminalScope.Exceptions;

public class TerminalNotFoundException : DomainException
{
    public TerminalNotFoundException()
    {
    }

    public TerminalNotFoundException(string message) : base(message)
    {
    }

    public TerminalNotFoundException(string message, Exception inner) : base(message, inner)
    {
    }
}