using FacilityAccessService.Business.Access.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.Access.Actions
{
    public class RevokeAccessObjectValidator : AbstractValidator<RevokeAccessObjectModel>
    {
        public RevokeAccessObjectValidator()
        {
            RuleFor(model => model.UserId).NotNull();
            RuleFor(model => model.ObjectId).NotNull();
        }
    }
}