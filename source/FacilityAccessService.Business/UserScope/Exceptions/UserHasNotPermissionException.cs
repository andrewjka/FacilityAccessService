using System;
using FacilityAccessService.Business.CommonScope.Exceptions;

namespace FacilityAccessService.Business.UserScope.Exceptions
{
    public class UserHasNotPermissionException : BusinessException
    {
        public UserHasNotPermissionException()
        {
        }

        public UserHasNotPermissionException(string message) : base(message)
        {
        }

        public UserHasNotPermissionException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}