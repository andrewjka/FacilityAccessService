#region

using System;

#endregion

namespace Presentation.Common.Exceptions;

public class RestServiceException : Exception
{
    public RestServiceException()
    {
    }

    public RestServiceException(string message) : base(message)
    {
    }

    public RestServiceException(string message, Exception inner) : base(message, inner)
    {
    }
}