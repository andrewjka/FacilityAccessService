using FacilityAccessService.Business.AccessScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.AccessScope.Actions
{
    public class GrantAccessObjectValidator : AbstractValidator<GrantAccessFacilityModel>
    {
        public GrantAccessObjectValidator()
        {
            RuleFor(model => model.UserId).NotNull();
            RuleFor(model => model.FacilityId).NotNull();
            RuleFor(model => model.AccessPeriod).NotNull();
        }
    }
}