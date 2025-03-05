using FacilityAccessService.Business.Access.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.Access.Actions
{
    public class VerifyAccessViaTerminalValidator : AbstractValidator<VerifyAccessViaTerminalModel>
    {
        public VerifyAccessViaTerminalValidator()
        {
            RuleFor(model => model.UserId).NotNull();
            RuleFor(model => model.TokenTerminal).NotNull();
            RuleFor(model => model.ObjectId).NotNull();
        }
    }
}