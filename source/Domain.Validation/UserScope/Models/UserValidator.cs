using Domain.UserScope.Models;
using FluentValidation;

namespace Domain.Validation.UserScope.Models;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(model => model.Id).NotEmpty();
        RuleFor(model => model.Role).NotNull();
        RuleFor(model => model.Email).EmailAddress().MaximumLength(512);
        RuleFor(model => model.Password).NotNull().MinimumLength(8).MaximumLength(512);
    }
}