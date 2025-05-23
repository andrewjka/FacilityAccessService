#region

using System;

#endregion

namespace Presentation.Common.Exceptions;

public class HeaderHasNotFound : RestServiceException
{
    public HeaderHasNotFound()
    {
    }

    public HeaderHasNotFound(string message) : base(message)
    {
    }

    public HeaderHasNotFound(string message, Exception inner) : base(message, inner)
    {
    }
}