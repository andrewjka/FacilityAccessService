
using FacilityAccessService.Business.AccessScope.Actions.Abstractions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.AccessScope.Actions
{
    public class VerifyAccessValidator : AbstractValidator<VerifyAccessModel>
    {
        public VerifyAccessValidator()
        {
            RuleFor(model => model.UserId).NotEmpty();
            RuleFor(model => model.FacilityId).NotNull();
        }
    }
}