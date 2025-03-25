#region

using System;
using FacilityAccessService.Business.CommonScope.Exceptions;

#endregion

namespace FacilityAccessService.Business.FacilityScope.Exceptions
{
    public class FacilityNotFoundException : BusinessException
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