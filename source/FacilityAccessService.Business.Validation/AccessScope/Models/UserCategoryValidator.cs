using FacilityAccessService.Business.AccessScope.Models;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.AccessScope.Models
{
    public class UserCategoryValidator : AbstractValidator<UserCategory>
    {
        public UserCategoryValidator()
        {
            RuleFor(model => model.UserId).NotEmpty();
            RuleFor(model => model.CategoryId).NotNull();
            RuleFor(model => model.AccessPeriod).NotNull();
        }
    }
}