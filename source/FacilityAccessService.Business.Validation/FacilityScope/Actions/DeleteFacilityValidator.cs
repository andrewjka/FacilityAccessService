using FacilityAccessService.Business.FacilityScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.FacilityScope.Actions
{
    public class DeleteFacilityValidator : AbstractValidator<DeleteFacilityModel>
    {
        public DeleteFacilityValidator()
        {
            RuleFor(model => model.ObjectId).NotNull();
        }
    }
}