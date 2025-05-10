using Domain.FacilityScope.Actions;
using FluentValidation;

namespace Domain.Validation.FacilityScope.Actions;

public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryModel>
{
    public DeleteCategoryValidator()
    {
        RuleFor(model => model.CategoryId).NotNull();
    }
}