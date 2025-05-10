#region

using System;
using Domain.CommonScope.Models;
using Domain.TerminalScope.ValueObjects;

#endregion

namespace Domain.TerminalScope.Models;

/// <summary>
///     Describes a device that can check user's access to a facility.
/// </summary>
public class Terminal : BaseEntity
{
    public Terminal(string name, TerminalToken token, DateOnly expiredTokenOn)
    {
        Name = name;
        Token = token;
        ExpiredTokenOn = expiredTokenOn;
    }

    public string Name { get; private set; }
    public TerminalToken Token { get; private set; }
    public DateOnly ExpiredTokenOn { get; private set; }

    /// <summary>
    ///     Changes the Terminal name.
    /// </summary>
    public void ChangeName(string name)
    {
        Name = name;
    }

    /// <summary>
    ///     Changes the expiration date of the terminal token.
    /// </summary>
    public void ChangeExpiredTokenOn(DateOnly expiredToken)
    {
        ExpiredTokenOn = expiredToken;
    }

    /// <summary>
    ///     Checks if the token is valid on the specified date.
    /// </summary>
    public bool IsTokenExpired(DateOnly date)
    {
        return ExpiredTokenOn < date;
    }
}