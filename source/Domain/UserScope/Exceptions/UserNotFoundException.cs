#region

using System;
using Domain.CommonScope.Exceptions;

#endregion

namespace Domain.UserScope.Exceptions;

public class UserNotFoundException : BusinessException
{
    public UserNotFoundException()
    {
    }

    public UserNotFoundException(string message) : base(message)
    {
    }

    public UserNotFoundException(string message, Exception inner) : base(message, inner)
    {
    }
}