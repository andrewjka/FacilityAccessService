using System;
using FacilityAccessService.Business.CommonScope.Models;
using FacilityAccessService.Business.TerminalScope.ValueObjects;

namespace FacilityAccessService.Business.TerminalScope.Models
{
    /// <summary>
    /// Describes a device that can check user's access to a facility.
    /// </summary>
    public class Terminal : BaseEntity
    {
        public string Name { get; private set; }
        public TerminalToken Token { get; private set; }
        public DateOnly ExpiredTokenOn { get; private set; }


        public Terminal(string name, TerminalToken token, DateOnly expiredTokenOn) : base()
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

        public bool IsTokenExpired(DateOnly date)
        {
            return ExpiredTokenOn < date;
        }
    }
}