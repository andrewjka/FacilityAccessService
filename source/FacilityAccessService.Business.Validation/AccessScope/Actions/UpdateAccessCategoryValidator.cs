using FacilityAccessService.Business.FacilityScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.AccessScope.Actions
{
    public class UpdateAccessCategoryValidator : AbstractValidator<UpdateCategoryModel>
    {
        public UpdateAccessCategoryValidator()
        {
            RuleFor(model => model.CategoryId).NotNull();
        }
    }
}