using FacilityAccessService.Business.Object.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.Object.Actions
{
    public class CreateObjectValidator : AbstractValidator<CreateObjectModel>
    {
        public CreateObjectValidator()
        {
            RuleFor(model => model).NotEmpty();
        }
    }
}