using FacilityAccessService.Business.User.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.User.Actions
{
    public class RegistryUserValidator : AbstractValidator<RegistryUserModel>
    {
        public RegistryUserValidator()
        {
            RuleFor(model => model.ExternalUserId).NotEmpty();
        }
    }
}