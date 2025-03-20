using FacilityAccessService.Business.AccessScope.Actions;
using FacilityAccessService.Business.FacilityScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.AccessScope.Actions
{
    public class UpdateAccessFacilityValidator : AbstractValidator<UpdateAccessFacilityModel>
    {
        public UpdateAccessFacilityValidator()
        {
            RuleFor(model => model.UserId).NotNull();
            RuleFor(model => model.FacilityId).NotNull();
            RuleFor(model => model.AccessPeriod).NotNull();
        }
    }
}