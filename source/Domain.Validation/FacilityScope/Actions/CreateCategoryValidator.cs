using Domain.FacilityScope.Actions;
using FluentValidation;

namespace Domain.Validation.FacilityScope.Actions;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryModel>
{
    public CreateCategoryValidator()
    {
        RuleFor(model => model.Name).NotEmpty();
        RuleFor(model => model.FacilitiesId).NotEmpty();
    }
}