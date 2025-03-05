using FacilityAccessService.Business.Access.Models;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.Access.Models
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