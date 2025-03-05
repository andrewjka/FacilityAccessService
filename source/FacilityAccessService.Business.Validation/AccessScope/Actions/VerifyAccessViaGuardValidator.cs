using FacilityAccessService.Business.AccessScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.AccessScope.Actions
{
    public class VerifyAccessViaGuardValidator : AbstractValidator<VerifyAccessViaGuardModel>
    {
        public VerifyAccessViaGuardValidator()
        {
            RuleFor(model => model.UserId).NotNull();
            RuleFor(model => model.GuarderId).NotNull();
            RuleFor(model => model.ObjectId).NotNull();
        }
    }
}