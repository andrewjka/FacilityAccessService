using Domain.FacilityScope.Models;
using FluentValidation;

namespace Domain.Validation.FacilityScope.Models;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(model => model.Id).NotEmpty();
        RuleFor(model => model.Name).NotNull();
    }
}