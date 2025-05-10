using Domain.AccessScope.Actions;
using FluentValidation;

namespace Domain.Validation.AccessScope.Actions;

public class GrantAccessFacilityValidator : AbstractValidator<GrantAccessFacilityModel>
{
    public GrantAccessFacilityValidator()
    {
        RuleFor(model => model.UserId).NotEmpty();
        RuleFor(model => model.FacilityId).NotNull();
        RuleFor(model => model.AccessPeriod).NotNull();
    }
}