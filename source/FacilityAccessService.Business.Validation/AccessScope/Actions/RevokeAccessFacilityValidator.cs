using FacilityAccessService.Business.AccessScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.AccessScope.Actions
{
    public class RevokeAccessFacilityValidator : AbstractValidator<RevokeAccessFacilityModel>
    {
        public RevokeAccessFacilityValidator()
        {
            RuleFor(model => model.UserId).NotEmpty();
            RuleFor(model => model.FacilityId).NotNull();
        }
    }
}