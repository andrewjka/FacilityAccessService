using FacilityAccessService.Business.ObjectScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.ObjectScope.Actions
{
    public class DeleteObjectValidator : AbstractValidator<DeleteObjectModel>
    {
        public DeleteObjectValidator()
        {
            RuleFor(model => model.ObjectId).NotNull();
        }
    }
}