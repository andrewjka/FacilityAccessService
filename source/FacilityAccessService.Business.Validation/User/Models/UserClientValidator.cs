using FacilityAccessService.Business.User.Models;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.User.Models
{
    public class UserClientValidator : AbstractValidator<UserClient>
    {
        public UserClientValidator()
        {
            RuleFor(model => model.Id).NotNull();
            
            RuleFor(model => model.ExternalUserId).NotNull();

            RuleFor(model => model.Role).NotNull();
        }
    }
}