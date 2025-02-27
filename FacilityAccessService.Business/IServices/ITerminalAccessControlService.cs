using FacilityAccessService.Business.Entities;

namespace FacilityAccessService.Business.IServices
{
    public interface ITerminalAccessControlService
    {
        public bool VerifyAccess(TerminalClient terminal, UserClient checkedPerson);
    }
}