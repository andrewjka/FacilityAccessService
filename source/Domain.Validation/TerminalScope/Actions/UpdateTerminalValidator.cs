using Domain.TerminalScope.Actions;
using FluentValidation;

namespace Domain.Validation.TerminalScope.Actions;

public class UpdateTerminalValidator : AbstractValidator<UpdateTerminalModel>
{
    public UpdateTerminalValidator()
    {
        RuleFor(model => model.TerminalId).NotNull();
    }
}