using FacilityAccessService.Business.AccessScope.Models;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.AccessScope.Models
{
    public class UserFacilityValidator : AbstractValidator<UserFacility>
    {
        public UserFacilityValidator()
        {
            RuleFor(model => model.UserId).NotEmpty();
            RuleFor(model => model.FacilityId).NotNull();
            RuleFor(model => model.AccessPeriod).NotNull();
        }
    }
}