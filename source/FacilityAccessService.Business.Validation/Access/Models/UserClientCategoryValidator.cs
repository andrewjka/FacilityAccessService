using FacilityAccessService.Business.Access.Models;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.Access.Models
{
    public class UserClientCategoryValidator : AbstractValidator<UserClientCategory>
    {
        public UserClientCategoryValidator()
        {
            RuleFor(model => model.Id).NotNull();
            
            RuleFor(model => model.UserClientId).NotNull();
            
            RuleFor(model => model.CategoryId).NotNull();
            
            RuleFor(model => model.AccessPeriod).NotNull();
        }
    }
}