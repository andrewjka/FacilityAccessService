using Domain.AccessScope.Models;
using FluentValidation;

namespace Domain.Validation.AccessScope.Models;

public class UserCategoryValidator : AbstractValidator<UserCategory>
{
    public UserCategoryValidator()
    {
        RuleFor(model => model.UserId).NotEmpty();
        RuleFor(model => model.CategoryId).NotNull();
        RuleFor(model => model.AccessPeriod).NotNull();
    }
}