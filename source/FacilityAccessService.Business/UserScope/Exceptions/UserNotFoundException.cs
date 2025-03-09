using System;
using FacilityAccessService.Business.CommonScope.Exceptions;

namespace FacilityAccessService.Business.UserScope.Exceptions
{
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
}