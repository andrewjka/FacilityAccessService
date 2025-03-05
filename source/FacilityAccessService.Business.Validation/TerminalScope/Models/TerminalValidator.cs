using FacilityAccessService.Business.TerminalScope.Models;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.TerminalScope.Models
{
    public class TerminalValidator : AbstractValidator<Business.TerminalScope.Models.Terminal>
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