using System;
using FacilityAccessService.Business.TerminalScope.ValueObjects;
using FacilityAccessService.Persistence.CommonScope.Models;

namespace FacilityAccessService.Persistence.TerminalScope.Models
{
    public class Terminal : BaseEntity
    {
        public string Name { get; set; }
        public TerminalToken Token { get; set; }
        public DateOnly ExpiredTokenOn { get; set; }
    }
}