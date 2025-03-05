using FacilityAccessService.Business.TerminalScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.TerminalScope.Actions
{
    public class CreateTerminalValidator : AbstractValidator<CreateTerminalModel>
    {
        public CreateTerminalValidator()
        {
            RuleFor(model => model.Name).NotEmpty();
            RuleFor(model => model.ExpiredTokenOn).NotNull();
        }
    }
}