using System;
using FacilityAccessService.Business.CommonScope.Exceptions;

namespace FacilityAccessService.Business.TerminalScope.Exceptions
{
    public class TerminalTokenInvalidException : BusinessException
    {
        public TerminalTokenInvalidException()
        {
        }

        public TerminalTokenInvalidException(string message) : base(message)
        {
        }

        public TerminalTokenInvalidException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}