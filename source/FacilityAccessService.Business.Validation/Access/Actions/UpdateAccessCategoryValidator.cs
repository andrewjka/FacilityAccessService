using FacilityAccessService.Business.Object.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.Access.Actions
{
    public class UpdateAccessCategoryValidator : AbstractValidator<UpdateCategoryModel>
    {
        public UpdateAccessCategoryValidator()
        {
            RuleFor(model => model.CategoryId).NotNull();
        }
    }
}