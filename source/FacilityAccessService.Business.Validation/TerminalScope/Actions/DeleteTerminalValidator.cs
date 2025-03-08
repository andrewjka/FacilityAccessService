using FacilityAccessService.Business.TerminalScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.TerminalScope.Actions
{
    public class DeleteTerminalValidator : AbstractValidator<DeleteTerminalModel>
    {
        public DeleteTerminalValidator()
        {
            RuleFor(model => model.TerminalId).NotNull();
        }
    }
}