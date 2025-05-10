using System;
using Domain.TerminalScope.ValueObjects;
using Persistence.CommonScope.Models;

namespace Persistence.TerminalScope.Models;

public class Terminal : BaseEntity
{
    public string Name { get; set; }
    public TerminalToken Token { get; set; }
    public DateOnly ExpiredTokenOn { get; set; }
}