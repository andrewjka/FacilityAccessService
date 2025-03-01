using System;
using FacilityAccessService.Business.Common;

namespace FacilityAccessService.Business.Terminal.Models
{
    /// <summary>
    /// Describes a device that can check user's access to a facility.
    /// </summary>
    public class TerminalClient : BaseEntity
    {
        public string Name { get; private set; }
        public string Token { get; private set; }
        public DateOnly ExpiredTokenOn { get; private set; }


        public TerminalClient(string name, string token, DateOnly expiredTokenOn)
        {
            this.Name = name;
            this.Token = token;
            this.ExpiredTokenOn = expiredTokenOn;
        }
        
        public void ChangeName(string name)
        {
            this.Name = name;
        }
        
        public void ChangeExpiredTokenOn(DateOnly expiredToken)
        {
            this.ExpiredTokenOn = expiredToken;
        }
    }
}