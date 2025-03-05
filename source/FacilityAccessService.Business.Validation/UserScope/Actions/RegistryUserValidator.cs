using FacilityAccessService.Business.UserScope.Actions;
using FluentValidation;

namespace FacilityAccessService.Business.Validation.UserScope.Actions
{
    public class RegistryUserValidator : AbstractValidator<RegistryUserModel>
    {
        public RegistryUserValidator()
        {
            RuleFor(model => model.ExternalUserId).NotEmpty();
        }
    }
}