#region

using System;
using FacilityAccessService.Business.CommonScope.Models;
using FacilityAccessService.Business.TerminalScope.ValueObjects;

#endregion

namespace FacilityAccessService.Business.TerminalScope.Models
{
    /// <summary>
    /// Describes a device that can check user's access to a facility.
    /// </summary>
    public class Terminal : BaseEntity
    {
        public Terminal(string name, TerminalToken token, DateOnly expiredTokenOn) : base()
        {
            this.Name = name;
            this.Token = token;
            this.ExpiredTokenOn = expiredTokenOn;
        }

        public string Name { get; private set; }
        public TerminalToken Token { get; private set; }
        public DateOnly ExpiredTokenOn { get; private set; }

        /// <summary>
        /// Changes the Terminal name.
        /// </summary>
        public void ChangeName(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Changes the expiration date of the terminal token. 
        /// </summary>
        public void ChangeExpiredTokenOn(DateOnly expiredToken)
        {
            this.ExpiredTokenOn = expiredToken;
        }

        /// <summary>
        /// Checks if the token is valid on the specified date.
        /// </summary>
        public bool IsTokenExpired(DateOnly date)
        {
            return ExpiredTokenOn < date;
        }
    }
}