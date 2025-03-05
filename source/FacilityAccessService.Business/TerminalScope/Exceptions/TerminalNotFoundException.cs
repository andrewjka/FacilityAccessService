using System;
using FacilityAccessService.Business.CommonScope;

namespace FacilityAccessService.Business.TerminalScope.Exceptions
{
    public class TerminalNotFoundException : DomainException
    {
        public TerminalNotFoundException()
        {
        }

        public TerminalNotFoundException(string message) : base(message)
        {
        }

        public TerminalNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}