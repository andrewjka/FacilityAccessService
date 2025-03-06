using FluentValidation;

namespace FacilityAccessService.Business.Validation.FacilityScope.Models
{
    public class ObjectValidator : AbstractValidator<Business.FacilityScope.Models.Facility>
    {
        public ObjectValidator()
        {
            RuleFor(model => model.Id).NotNull();
            RuleFor(model => model.Name).NotEmpty();
        }
    }
}