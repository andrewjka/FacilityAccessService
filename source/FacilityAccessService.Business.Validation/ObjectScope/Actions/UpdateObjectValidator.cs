using FacilityAccessService.Business.ObjectScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.ObjectScope.Actions
{
    public class UpdateObjectValidator : AbstractValidator<UpdateObjectModel>
    {
        public UpdateObjectValidator()
        {
            RuleFor(model => model.ObjectId).NotNull();
        }
    }
}