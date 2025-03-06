using FacilityAccessService.Business.FacilityScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.AccessScope.Actions
{
    public class UpdateAccessObjectValidator : AbstractValidator<UpdateFacilityModel>
    {
        public UpdateAccessObjectValidator()
        {
            RuleFor(model => model.ObjectId).NotNull();
        }
    }
}