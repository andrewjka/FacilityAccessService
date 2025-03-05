using FacilityAccessService.Business.Object.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.Object.Actions
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryModel>
    {
        public CreateCategoryValidator()
        {
            RuleFor(model => model.Name).NotEmpty();
            RuleFor(model => model.Objects).NotEmpty();
        }
    }
}