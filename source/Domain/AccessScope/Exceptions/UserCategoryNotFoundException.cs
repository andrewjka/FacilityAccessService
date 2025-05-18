#region

using System;
using Domain.CommonScope.Exceptions;

#endregion

namespace Domain.AccessScope.Exceptions;

public class UserCategoryNotFoundException : DomainException
{
    public UserCategoryNotFoundException()
    {
    }

    public UserCategoryNotFoundException(string message) : base(message)
    {
    }

    public UserCategoryNotFoundException(string message, Exception inner) : base(message, inner)
    {
    }
}