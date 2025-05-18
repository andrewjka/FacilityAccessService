#region

using System;
using Domain.CommonScope.Exceptions;

#endregion

namespace Domain.FacilityScope.Exceptions;

public class CategoryNotFoundException : DomainException
{
    public CategoryNotFoundException()
    {
    }

    public CategoryNotFoundException(string message) : base(message)
    {
    }

    public CategoryNotFoundException(string message, Exception inner) : base(message, inner)
    {
    }
}