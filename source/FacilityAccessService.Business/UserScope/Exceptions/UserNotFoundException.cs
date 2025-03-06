using System;
using FacilityAccessService.Business.CommonScope;

namespace FacilityAccessService.Business.UserScope.Exceptions
{
    public class UserNotFoundException : DomainException
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
}