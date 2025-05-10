#region

using System;
using Domain.CommonScope.Exceptions;

#endregion

namespace Domain.AccessScope.Exceptions;

public class UserFacilityNotFoundException : BusinessException
{
    public UserFacilityNotFoundException()
    {
    }

    public UserFacilityNotFoundException(string message) : base(message)
    {
    }

    public UserFacilityNotFoundException(string message, Exception inner) : base(message, inner)
    {
    }
}