using FacilityAccessService.Business.TerminalScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.TerminalScope.Actions
{
    public class UpdateTerminalValidator : AbstractValidator<UpdateTerminalModel>
    {
        public UpdateTerminalValidator()
        {
            RuleFor(model => model.TerminalId).NotNull();
        }
    }
}