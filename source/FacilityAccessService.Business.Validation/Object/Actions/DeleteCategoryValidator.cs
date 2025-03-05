using FacilityAccessService.Business.Object.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.Object.Actions
{
    public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryModel>
    {
        public DeleteCategoryValidator()
        {
            RuleFor(model => model.CategoryId).NotNull();
        }
    }
}