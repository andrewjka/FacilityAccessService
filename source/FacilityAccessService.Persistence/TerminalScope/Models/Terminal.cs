using System;
using FacilityAccessService.Business.TerminalScope.ValueObjects;
using FacilityAccessService.Persistence.CommonScope.Models;

namespace FacilityAccessService.Persistence.TerminalScope.Models
{
    public class Terminal : BaseEntity
    {
        public string Name { get; private set; }
        public TerminalToken Token { get; private set; }
        public DateOnly ExpiredTokenOn { get; private set; }
    }
}