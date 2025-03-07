using FacilityAccessService.Business.AccessScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.AccessScope.Actions
{
    public class VerifyAccessViaTerminalValidator : AbstractValidator<VerifyAccessViaTerminalModel>
    {
        public VerifyAccessViaTerminalValidator()
        {
            RuleFor(model => model.UserId).NotNull();
            RuleFor(model => model.TokenTerminal).NotNull();
            RuleFor(model => model.FacilityId).NotNull();
        }
    }
}