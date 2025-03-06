using FacilityAccessService.Business.FacilityScope.Models;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.FacilityScope.Models
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(model => model.Id).NotNull();
            RuleFor(model => model.Name).NotNull();
        }
    }
}