using System;
using FacilityAccessService.Business.CommonScope;

namespace FacilityAccessService.Business.FacilityScope.Exceptions
{
    public class ObjectNotFoundException : DomainException
    {
        public ObjectNotFoundException()
        {
        }

        public ObjectNotFoundException(string message) : base(message)
        {
        }

        public ObjectNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}