using FacilityAccessService.Business.ObjectScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.ObjectScope.Actions
{
    public class CreateObjectValidator : AbstractValidator<CreateObjectModel>
    {
        public CreateObjectValidator()
        {
            RuleFor(model => model).NotEmpty();
        }
    }
}