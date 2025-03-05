using FacilityAccessService.Business.Object.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.Object.Actions
{
    public class UpdateObjectValidator : AbstractValidator<UpdateObjectModel>
    {
        public UpdateObjectValidator()
        {
            RuleFor(model => model.ObjectId).NotNull();
        }
    }
}