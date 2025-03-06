using FacilityAccessService.Business.FacilityScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.FacilityScope.Actions
{
    public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryModel>
    {
        public DeleteCategoryValidator()
        {
            RuleFor(model => model.CategoryId).NotNull();
        }
    }
}