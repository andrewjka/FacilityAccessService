#region

using System;
using FacilityAccessService.Business.CommonScope.Exceptions;

#endregion

namespace FacilityAccessService.Business.TerminalScope.Exceptions
{
    public class TerminalNotFoundException : BusinessException
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