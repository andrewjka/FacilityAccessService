using FacilityAccessService.Business.AccessScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.AccessScope.Actions
{
    public class VerifyAccessViaGuardValidator : AbstractValidator<VerifyAccessViaGuardModel>
    {
        public VerifyAccessViaGuardValidator()
        {
            RuleFor(model => model.UserId).NotEmpty();
            RuleFor(model => model.GuarderId).NotEmpty();
            RuleFor(model => model.FacilityId).NotNull();
        }
    }
}