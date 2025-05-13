using Domain.UserScope.Actions;
using FluentValidation;

namespace Domain.Validation.UserScope.Actions;

public class RegistryUserValidator : AbstractValidator<RegistryUserModel>
{
    public RegistryUserValidator()
    {
        RuleFor(model => model.Email).EmailAddress().MaximumLength(512);
        RuleFor(model => model.Password).NotNull().MinimumLength(8).MaximumLength(512);
    }
}