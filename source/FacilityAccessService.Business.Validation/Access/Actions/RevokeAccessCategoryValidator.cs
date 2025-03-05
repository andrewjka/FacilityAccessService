using FacilityAccessService.Business.Access.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.Access.Actions
{
    public class RevokeAccessCategoryValidator : AbstractValidator<RevokeAccessCategoryModel>
    {
        public RevokeAccessCategoryValidator()
        {
            RuleFor(model => model.UserId).NotNull();
            RuleFor(model => model.CategoryId).NotNull();
        }
    }
}