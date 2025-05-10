using Domain.FacilityScope.Actions;
using FluentValidation;

namespace Domain.Validation.FacilityScope.Actions;

public class UpdateFacilityValidator : AbstractValidator<UpdateFacilityModel>
{
    public UpdateFacilityValidator()
    {
        RuleFor(model => model.FacilityId).NotNull();
    }
}