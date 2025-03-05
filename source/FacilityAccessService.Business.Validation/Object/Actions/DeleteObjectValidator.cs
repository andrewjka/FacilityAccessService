using FacilityAccessService.Business.Object.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.Object.Actions
{
    public class DeleteObjectValidator : AbstractValidator<DeleteObjectModel>
    {
        public DeleteObjectValidator()
        {
            RuleFor(model => model.ObjectId).NotNull();
        }
    }
}