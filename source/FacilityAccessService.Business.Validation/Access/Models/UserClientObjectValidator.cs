using FacilityAccessService.Business.Access.Models;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.Access.Models
{
    public class UserClientObjectValidator : AbstractValidator<UserObject>
    {
        public UserClientObjectValidator()
        {
            RuleFor(model => model.Id).NotNull();
            
            RuleFor(model => model.UserId).NotNull();
            
            RuleFor(model => model.ObjectId).NotNull();
            
            RuleFor(model => model.AccessPeriod).NotNull();
        }
    }
}