using System;
using FacilityAccessService.Business.CommonScope;

namespace FacilityAccessService.Business.FacilityScope.Exceptions
{
    public class FacilityNotFoundException : DomainException
    {
        public FacilityNotFoundException()
        {
        }

        public FacilityNotFoundException(string message) : base(message)
        {
        }

        public FacilityNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}