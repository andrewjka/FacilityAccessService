using Domain.AccessScope.Actions;
using FluentValidation;

namespace Domain.Validation.AccessScope.Actions;

public class UpdateAccessFacilityValidator : AbstractValidator<UpdateAccessFacilityModel>
{
    public UpdateAccessFacilityValidator()
    {
        RuleFor(model => model.UserId).NotNull();
        RuleFor(model => model.FacilityId).NotNull();
        RuleFor(model => model.AccessPeriod).NotNull();
    }
}