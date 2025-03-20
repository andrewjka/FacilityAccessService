using FacilityAccessService.Business.FacilityScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.AccessScope.Actions
{
    public class UpdateAccessFacilityValidator : AbstractValidator<UpdateFacilityModel>
    {
        public UpdateAccessFacilityValidator()
        {
            RuleFor(model => model.FacilityId).NotNull();
        }
    }
}