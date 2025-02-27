using FacilityAccessService.Business.Entities;

namespace FacilityAccessService.Business.IServices
{
    public interface IAccessControlService
    {
        public bool VerifyAccess(UserClient controlOfficer, UserClient checkedPerson);
    }
}