using FacilityAccessService.Business.AccessScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.AccessScope.Actions
{
    public class GrantAccessCategoryValidator : AbstractValidator<GrantAccessCategoryModel>
    {
        public GrantAccessCategoryValidator() : base()
        {
            RuleFor(model => model.UserId).NotEmpty();
            RuleFor(model => model.CategoryId).NotNull();
            RuleFor(model => model.AccessPeriod).NotNull();
        }
    }
}