#region

using System;
using Domain.AccessScope.Models;
using Domain.CommonScope.Specification;

#endregion

namespace Domain.AccessScope.Specifications;

public class ExpiredAccessCategorySpecification : Specification<UserCategory>
{
    public ExpiredAccessCategorySpecification(int take)
    {
        ApplyExpression(userClientCategory =>
            userClientCategory.AccessPeriod.EndDate < DateOnly.FromDateTime(DateTime.Today)
        );

        ApplyPaging(0, take);
    }
}