using FacilityAccessService.Business.Access.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.Access.Actions
{
    public class GrantAccessCategoryValidator : AbstractValidator<GrantAccessCategoryModel>
    {
        public GrantAccessCategoryValidator() : base()
        {
            RuleFor(model => model.UserId).NotNull();
            RuleFor(model => model.CategoryId).NotNull();
            RuleFor(model => model.AccessPeriod).NotNull();
        }
    }
}