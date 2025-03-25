#region

using System;
using FacilityAccessService.Business.CommonScope.Exceptions;

#endregion

namespace FacilityAccessService.Business.AccessScope.Exceptions
{
    public class UserCategoryNotFoundException : BusinessException
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
}