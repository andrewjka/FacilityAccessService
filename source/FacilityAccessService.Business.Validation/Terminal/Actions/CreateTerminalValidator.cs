using FacilityAccessService.Business.Terminal.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.Terminal.Actions
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