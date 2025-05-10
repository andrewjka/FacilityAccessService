#region

using System;

#endregion

namespace Domain.CommonScope.Exceptions;

/// <summary>
///     Describes the basic business error for all subsequent ones.
/// </summary>
public class BusinessException : Exception
{
    public BusinessException()
    {
    }

    public BusinessException(string message) : base(message)
    {
    }

    public BusinessException(string message, Exception inner) : base(message, inner)
    {
    }
}