using FacilityAccessService.Business.Access.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.Access.Actions
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