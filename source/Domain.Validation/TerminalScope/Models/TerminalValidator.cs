using Domain.TerminalScope.Models;
using FluentValidation;

namespace Domain.Validation.TerminalScope.Models;

public class TerminalValidator : AbstractValidator<Terminal>
{
    public TerminalValidator()
    {
        RuleFor(model => model.Id).NotNull();
        RuleFor(model => model.Name).NotEmpty();
        RuleFor(model => model.Token).NotEmpty();
        RuleFor(model => model.ExpiredTokenOn).NotNull();
    }
}