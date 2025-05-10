using Domain.FacilityScope.Actions;
using FluentValidation;

namespace Domain.Validation.FacilityScope.Actions;

public class CreateFacilityValidator : AbstractValidator<CreateFacilityModel>
{
    public CreateFacilityValidator()
    {
        RuleFor(model => model.Name).NotEmpty();
    }
}