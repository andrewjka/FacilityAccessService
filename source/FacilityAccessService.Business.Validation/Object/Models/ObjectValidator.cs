using FluentValidation;

namespace FacilityAccessService.Business.Validation.Object.Models
{
    public class ObjectValidator : AbstractValidator<Business.Object.Models.Object>
    {
        public ObjectValidator()
        {
            RuleFor(model => model.Id).NotNull();
            
            RuleFor(model => model.Name).NotEmpty();
            
            // RuleFor(model => model.Description).NotEmpty();
        }
    }
}