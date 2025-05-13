using System;
using Domain.CommonScope.ValueObjects;
using Persistence.CommonScope.Models;

namespace Persistence.TerminalScope.Models;

public class Terminal : BaseEntity
{
    public string Name { get; set; }
    public Token512Bit Token { get; set; }
    public DateOnly ExpiredTokenOn { get; set; }
}