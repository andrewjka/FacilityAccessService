#region

using System;
using Domain.AccessScope.Models;
using Domain.CommonScope.Specification;

#endregion

namespace Domain.AccessScope.Specifications;

public class ExpiredAccessFacilitySpecification : Specification<UserFacility>
{
    public ExpiredAccessFacilitySpecification(int take)
    {
        ApplyExpression(userClientObject =>
            userClientObject.AccessPeriod.EndDate < DateOnly.FromDateTime(DateTime.Today)
        );

        ApplyPaging(0, take);
    }
}