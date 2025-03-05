using FacilityAccessService.Business.Object.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.Access.Actions
{
    public class UpdateAccessObjectValidator : AbstractValidator<UpdateObjectModel>
    {
        public UpdateAccessObjectValidator()
        {
            RuleFor(model => model.ObjectId).NotNull();
        }
    }
}