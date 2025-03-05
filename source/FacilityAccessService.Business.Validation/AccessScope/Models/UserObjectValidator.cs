using FacilityAccessService.Business.AccessScope.Models;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.AccessScope.Models
{
    public class UserObjectValidator : AbstractValidator<UserObject>
    {
        public UserObjectValidator()
        {
            RuleFor(model => model.Id).NotNull();
            
            RuleFor(model => model.UserId).NotNull();
            
            RuleFor(model => model.ObjectId).NotNull();
            
            RuleFor(model => model.AccessPeriod).NotNull();
        }
    }
}