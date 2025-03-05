using FluentValidation;

namespace FacilityAccessService.Business.Validation.ObjectScope.Models
{
    public class ObjectValidator : AbstractValidator<Business.ObjectScope.Models.Object>
    {
        public ObjectValidator()
        {
            RuleFor(model => model.Id).NotNull();
            RuleFor(model => model.Name).NotEmpty();
        }
    }
}