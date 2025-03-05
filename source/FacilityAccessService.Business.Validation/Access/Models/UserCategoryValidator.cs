using FacilityAccessService.Business.Access.Models;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.Access.Models
{
    public class UserCategoryValidator : AbstractValidator<UserCategory>
    {
        public UserCategoryValidator()
        {
            RuleFor(model => model.Id).NotNull();
            
            RuleFor(model => model.UserId).NotNull();
            
            RuleFor(model => model.CategoryId).NotNull();
            
            RuleFor(model => model.AccessPeriod).NotNull();
        }
    }
}