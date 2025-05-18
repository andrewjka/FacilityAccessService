#region

using System;

#endregion

namespace Domain.CommonScope.Exceptions;

/// <summary>
///     Describes the basic business error for all subsequent ones.
/// </summary>
public class DomainException : Exception
{
    public DomainException()
    {
    }

    public DomainException(string message) : base(message)
    {
    }

    public DomainException(string message, Exception inner) : base(message, inner)
    {
    }
}