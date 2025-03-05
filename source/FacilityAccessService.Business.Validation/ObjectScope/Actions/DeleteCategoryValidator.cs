using FacilityAccessService.Business.ObjectScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.ObjectScope.Actions
{
    public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryModel>
    {
        public DeleteCategoryValidator()
        {
            RuleFor(model => model.CategoryId).NotNull();
        }
    }
}