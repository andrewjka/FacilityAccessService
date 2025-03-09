using System;
using FacilityAccessService.Business.CommonScope.Exceptions;

namespace FacilityAccessService.Business.AccessScope.Exceptions
{
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
}