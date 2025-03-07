using System;
using FacilityAccessService.Business.CommonScope;

namespace FacilityAccessService.Business.AccessScope.Exceptions
{
    public class UserCategoryNotFoundException : DomainException
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