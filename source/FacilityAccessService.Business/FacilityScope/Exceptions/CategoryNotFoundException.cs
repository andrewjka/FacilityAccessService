using System;
using FacilityAccessService.Business.CommonScope;

namespace FacilityAccessService.Business.FacilityScope.Exceptions
{
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
}