using FluentValidation;

namespace FacilityAccessService.Business.Validation.User.Models
{
    public class UserValidator : AbstractValidator<Business.User.Models.User>
    {
        public UserValidator()
        {
            RuleFor(model => model.Id).NotNull();
            RuleFor(model => model.ExternalUserId).NotNull();
            RuleFor(model => model.Role).NotNull();
        }
    }
}