using FacilityAccessService.Business.ObjectScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.AccessScope.Actions
{
    public class UpdateAccessObjectValidator : AbstractValidator<UpdateObjectModel>
    {
        public UpdateAccessObjectValidator()
        {
            RuleFor(model => model.ObjectId).NotNull();
        }
    }
}