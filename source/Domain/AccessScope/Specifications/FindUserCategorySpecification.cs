#region

using System;
using Domain.AccessScope.Models;
using Domain.CommonScope.Specification;

#endregion

namespace Domain.AccessScope.Specifications;

public class FindUserCategorySpecification : Specification<UserCategory>
{
    /// <summary>
    ///     Finds the specific access of a user to a specific category.
    ///     <param name="isOnlyActive">If true, returns only non-expired records</param>
    /// </summary>
    public FindUserCategorySpecification(string userId, Guid categoryId, bool isOnlyActive = false)
    {
        var currentDate = DateOnly.FromDateTime(DateTime.Today);

        if (isOnlyActive)
            ApplyExpression(userCategory =>
                userCategory.UserId == userId && userCategory.CategoryId == categoryId &&
                currentDate >= userCategory.AccessPeriod.StartDate &&
                currentDate <= userCategory.AccessPeriod.EndDate
            );
        else
            ApplyExpression(userCategory =>
                userCategory.UserId == userId && userCategory.CategoryId == categoryId
            );
    }

    /// <summary>
    ///     Finds all categories to which the user has access.
    /// </summary>
    /// <param name="isOnlyActive">If true, returns only non-expired records</param>
    public FindUserCategorySpecification(string userId, bool isOnlyActive = false)
    {
        var currentDate = DateOnly.FromDateTime(DateTime.Today);

        if (isOnlyActive)
            ApplyExpression(userCategory =>
                userCategory.UserId == userId &&
                currentDate >= userCategory.AccessPeriod.StartDate &&
                currentDate <= userCategory.AccessPeriod.EndDate
            );
        else
            ApplyExpression(userCategory =>
                userCategory.UserId == userId
            );
    }
}