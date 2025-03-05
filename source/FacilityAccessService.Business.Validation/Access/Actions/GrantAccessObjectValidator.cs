using FacilityAccessService.Business.Access.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.Access.Actions
{
    public class GrantAccessObjectValidator : AbstractValidator<GrantAccessObjectModel>
    {
        public GrantAccessObjectValidator()
        {
            RuleFor(model => model.UserId).NotNull();
            RuleFor(model => model.ObjectId).NotNull();
            RuleFor(model => model.AccessPeriod).NotNull();
        }
    }
}