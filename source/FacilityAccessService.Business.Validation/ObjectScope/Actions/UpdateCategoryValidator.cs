using FacilityAccessService.Business.ObjectScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.ObjectScope.Actions
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryModel>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(model => model.CategoryId).NotNull();
        }
    }
}