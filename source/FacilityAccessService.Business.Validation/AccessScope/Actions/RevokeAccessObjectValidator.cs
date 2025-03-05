using FacilityAccessService.Business.AccessScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.AccessScope.Actions
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