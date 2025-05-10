using Domain.FacilityScope.Models;
using FluentValidation;

namespace Domain.Validation.FacilityScope.Models;

public class FacilityValidator : AbstractValidator<Facility>
{
    public FacilityValidator()
    {
        RuleFor(model => model.Id).NotEmpty();
        RuleFor(model => model.Name).NotEmpty();
    }
}