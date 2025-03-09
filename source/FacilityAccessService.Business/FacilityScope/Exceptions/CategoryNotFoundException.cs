using System;
using FacilityAccessService.Business.CommonScope.Exceptions;

namespace FacilityAccessService.Business.FacilityScope.Exceptions
{
    public class CategoryNotFoundException : BusinessException
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