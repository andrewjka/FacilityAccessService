using Domain.AccessScope.Models;
using FluentValidation;

namespace Domain.Validation.AccessScope.Models;

public class UserFacilityValidator : AbstractValidator<UserFacility>
{
    public UserFacilityValidator()
    {
        RuleFor(model => model.UserId).NotEmpty();
        RuleFor(model => model.FacilityId).NotNull();
        RuleFor(model => model.AccessPeriod).NotNull();
    }
}