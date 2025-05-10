using Domain.TerminalScope.Actions;
using FluentValidation;

namespace Domain.Validation.TerminalScope.Actions;

public class DeleteTerminalValidator : AbstractValidator<DeleteTerminalModel>
{
    public DeleteTerminalValidator()
    {
        RuleFor(model => model.TerminalId).NotNull();
    }
}