using FacilityAccessService.Business.Object.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.Object.Actions
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryModel>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(model => model.CategoryId).NotNull();
        }
    }
}