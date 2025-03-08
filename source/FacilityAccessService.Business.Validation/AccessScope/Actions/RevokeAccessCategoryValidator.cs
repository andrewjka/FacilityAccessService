using FacilityAccessService.Business.AccessScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.AccessScope.Actions
{
    public class RevokeAccessCategoryValidator : AbstractValidator<RevokeAccessCategoryModel>
    {
        public RevokeAccessCategoryValidator()
        {
            RuleFor(model => model.UserId).NotEmpty();
            RuleFor(model => model.CategoryId).NotNull();
        }
    }
}