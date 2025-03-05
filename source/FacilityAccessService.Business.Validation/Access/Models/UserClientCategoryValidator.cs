using FacilityAccessService.Business.Access.Models;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.Access.Models
{
    public class UserClientCategoryValidator : AbstractValidator<UserCategory>
    {
        public UserClientCategoryValidator()
        {
            RuleFor(model => model.Id).NotNull();
            
            RuleFor(model => model.UserId).NotNull();
            
            RuleFor(model => model.CategoryId).NotNull();
            
            RuleFor(model => model.AccessPeriod).NotNull();
        }
    }
}