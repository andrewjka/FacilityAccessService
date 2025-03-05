using FacilityAccessService.Business.Terminal.Models;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.Terminal.Models
{
    public class TerminalValidator : AbstractValidator<Business.Terminal.Models.Terminal>
    {
        public TerminalValidator()
        {
            RuleFor(model => model.Id).NotNull();
            RuleFor(model => model.Name).NotEmpty();
            RuleFor(model => model.Token).NotEmpty();
            RuleFor(model => model.ExpiredTokenOn).NotNull();
        }
    }
}