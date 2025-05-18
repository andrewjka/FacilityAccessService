using Domain.AccessScope.Actions;
using FluentValidation;

namespace Domain.Validation.AccessScope.Actions;

public class VerifyAccessValidator : AbstractValidator<VerifyAccessModel>
{
    public VerifyAccessValidator()
    {
        RuleFor(model => model.PassToken).NotEmpty();
        RuleFor(model => model.FacilityId).NotNull();
    }
}