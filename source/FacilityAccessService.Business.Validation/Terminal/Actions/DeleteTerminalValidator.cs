using FacilityAccessService.Business.Terminal.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.Terminal.Actions
{
    public class DeleteTerminalValidator : AbstractValidator<DeleteTerminalModel>
    {
        public DeleteTerminalValidator()
        {
            RuleFor(model => model.Uid).NotNull();
        }
    }
}