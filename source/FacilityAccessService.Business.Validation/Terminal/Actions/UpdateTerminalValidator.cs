using FacilityAccessService.Business.Terminal.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.Terminal.Actions
{
    public class UpdateTerminalValidator : AbstractValidator<UpdateTerminalModel>
    {
        public UpdateTerminalValidator()
        {
            RuleFor(model => model.Uid).NotNull();
        }
    }
}