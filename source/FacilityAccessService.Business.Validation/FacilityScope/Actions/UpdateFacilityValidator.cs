using FacilityAccessService.Business.FacilityScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.FacilityScope.Actions
{
    public class UpdateFacilityValidator : AbstractValidator<UpdateFacilityModel>
    {
        public UpdateFacilityValidator()
        {
            RuleFor(model => model.FacilityId).NotNull();
        }
    }
}