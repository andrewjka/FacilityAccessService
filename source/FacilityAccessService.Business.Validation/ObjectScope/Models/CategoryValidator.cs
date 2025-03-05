using FacilityAccessService.Business.ObjectScope.Models;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.ObjectScope.Models
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