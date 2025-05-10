using Domain.AccessScope.Actions;
using FluentValidation;

namespace Domain.Validation.AccessScope.Actions;

public class GrantAccessCategoryValidator : AbstractValidator<GrantAccessCategoryModel>
{
    public GrantAccessCategoryValidator()
    {
        RuleFor(model => model.UserId).NotEmpty();
        RuleFor(model => model.CategoryId).NotNull();
        RuleFor(model => model.AccessPeriod).NotNull();
    }
}