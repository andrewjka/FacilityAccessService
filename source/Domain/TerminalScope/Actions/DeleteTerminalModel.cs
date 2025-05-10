#region

using System;

#endregion

namespace Domain.TerminalScope.Actions;

/// <summary>
///     The action model for delete the terminal.
/// </summary>
public record DeleteTerminalModel(Guid TerminalId);