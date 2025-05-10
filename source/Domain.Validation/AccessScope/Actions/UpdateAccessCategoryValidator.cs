using Domain.AccessScope.Actions;
using FluentValidation;

namespace Domain.Validation.AccessScope.Actions;

public class UpdateAccessCategoryValidator : AbstractValidator<UpdateAccessCategoryModel>
{
    public UpdateAccessCategoryValidator()
    {
        RuleFor(model => model.UserId).NotNull();
        RuleFor(model => model.CategoryId).NotNull();
        RuleFor(model => model.AccessPeriod).NotNull();
    }
}