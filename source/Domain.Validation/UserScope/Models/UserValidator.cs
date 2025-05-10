using Domain.UserScope.Models;
using FluentValidation;

namespace Domain.Validation.UserScope.Models;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(model => model.Id).NotEmpty();
        RuleFor(model => model.Role).NotNull();
    }
}