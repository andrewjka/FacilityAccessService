#region

using System;
using FacilityAccessService.Business.CommonScope.Exceptions;

#endregion

namespace FacilityAccessService.Business.UserScope.Exceptions
{
    public class UnauthorizedAccessException : BusinessException
    {
        public UnauthorizedAccessException()
        {
        }

        public UnauthorizedAccessException(string message) : base(message)
        {
        }

        public UnauthorizedAccessException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}