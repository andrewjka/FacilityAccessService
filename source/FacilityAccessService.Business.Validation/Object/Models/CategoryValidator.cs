using FacilityAccessService.Business.Object.Models;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.Object.Models
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