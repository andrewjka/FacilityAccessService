using Domain.TerminalScope.Actions;
using FluentValidation;

namespace Domain.Validation.TerminalScope.Actions;

public class CreateTerminalValidator : AbstractValidator<CreateTerminalModel>
{
    public CreateTerminalValidator()
    {
        RuleFor(model => model.Name).NotEmpty();
        RuleFor(model => model.ExpiredTokenOn).NotNull();
    }
}