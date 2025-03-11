using FacilityAccessService.Business.FacilityScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.FacilityScope.Actions
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryModel>
    {
        public CreateCategoryValidator()
        {
            RuleFor(model => model.Name).NotEmpty();
            RuleFor(model => model.FacilitiesId).NotEmpty();
        }
    }
}