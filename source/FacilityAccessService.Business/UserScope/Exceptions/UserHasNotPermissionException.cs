using System;
using FacilityAccessService.Business.CommonScope;

namespace FacilityAccessService.Business.UserScope.Exceptions
{
    public class UserHasNotPermissionException : DomainException
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