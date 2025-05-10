using Domain.UserScope.Actions;
using FluentValidation;

namespace Domain.Validation.UserScope.Actions;

public class RegistryUserValidator : AbstractValidator<RegistryUserModel>
{
    public RegistryUserValidator()
    {
        RuleFor(model => model.ExternalUserId).NotEmpty();
    }
}