#region

using System;

#endregion

namespace Domain.TerminalScope.Actions;

/// <summary>
///     The action model for create a terminal.
/// </summary>
public record CreateTerminalModel(string Name, DateOnly ExpiredTokenOn);