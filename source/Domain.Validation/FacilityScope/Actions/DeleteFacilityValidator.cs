using Domain.FacilityScope.Actions;
using FluentValidation;

namespace Domain.Validation.FacilityScope.Actions;

public class DeleteFacilityValidator : AbstractValidator<DeleteFacilityModel>
{
    public DeleteFacilityValidator()
    {
        RuleFor(model => model.FacilityId).NotNull();
    }
}