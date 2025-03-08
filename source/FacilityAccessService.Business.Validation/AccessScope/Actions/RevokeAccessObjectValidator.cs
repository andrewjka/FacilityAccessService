using FacilityAccessService.Business.AccessScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.AccessScope.Actions
{
    public class RevokeAccessObjectValidator : AbstractValidator<RevokeAccessFacilityModel>
    {
        public RevokeAccessObjectValidator()
        {
            RuleFor(model => model.UserId).NotEmpty();
            RuleFor(model => model.FacilityId).NotNull();
        }
    }
}