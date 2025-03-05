using System;
using FacilityAccessService.Business.Common.ValueObjects;

namespace FacilityAccessService.Business.Access.Models
{
    public interface IUserPassModel
    {
        public Guid UserId { get; }

        public AccessPeriod AccessPeriod { get; }
    }
}