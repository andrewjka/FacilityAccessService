using FacilityAccessService.Business.FacilityScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.FacilityScope.Actions
{
    public class CreateFacilityValidator : AbstractValidator<CreateFacilityModel>
    {
        public CreateFacilityValidator()
        {
            RuleFor(model => model.Name).NotEmpty();
        }
    }
}