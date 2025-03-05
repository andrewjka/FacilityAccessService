using FluentValidation;

namespace FacilityAccessService.Business.Validation.UserScope.Models
{
    public class UserValidator : AbstractValidator<Business.UserScope.Models.User>
    {
        public UserValidator()
        {
            RuleFor(model => model.Id).NotNull();
            RuleFor(model => model.ExternalUserId).NotNull();
            RuleFor(model => model.Role).NotNull();
        }
    }
}