using FacilityAccessService.Business.Access.Models;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.Access.Models
{
    public class UserClientObjectValidator : AbstractValidator<UserClientObject>
    {
        public UserClientObjectValidator()
        {
            RuleFor(model => model.Id).NotNull();
            
            RuleFor(model => model.UserClientId).NotNull();
            
            RuleFor(model => model.ObjectId).NotNull();
            
            RuleFor(model => model.AccessPeriod).NotNull();
        }
    }
}