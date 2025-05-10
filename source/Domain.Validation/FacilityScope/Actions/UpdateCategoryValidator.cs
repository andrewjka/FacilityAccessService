using Domain.FacilityScope.Actions;
using FluentValidation;

namespace Domain.Validation.FacilityScope.Actions;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryModel>
{
    public UpdateCategoryValidator()
    {
        RuleFor(model => model.CategoryId).NotNull();
    }
}