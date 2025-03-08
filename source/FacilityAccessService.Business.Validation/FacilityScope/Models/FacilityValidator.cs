using FluentValidation;

namespace FacilityAccessService.Business.Validation.FacilityScope.Models
{
    public class FacilityValidator : AbstractValidator<Business.FacilityScope.Models.Facility>
    {
        public FacilityValidator()
        {
            RuleFor(model => model.Id).NotEmpty();
            RuleFor(model => model.Name).NotEmpty();
        }
    }
}