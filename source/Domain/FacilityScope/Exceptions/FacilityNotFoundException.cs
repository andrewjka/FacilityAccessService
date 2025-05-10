#region

using System;
using Domain.CommonScope.Exceptions;

#endregion

namespace Domain.FacilityScope.Exceptions;

public class FacilityNotFoundException : BusinessException
{
    public FacilityNotFoundException()
    {
    }

    public FacilityNotFoundException(string message) : base(message)
    {
    }

    public FacilityNotFoundException(string message, Exception inner) : base(message, inner)
    {
    }
}