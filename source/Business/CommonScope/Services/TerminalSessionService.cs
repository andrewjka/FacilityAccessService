#region

using System;
using System.Threading.Tasks;
using Domain.CommonScope.PersistenceContext;
using Domain.CommonScope.Services;
using Domain.TerminalScope.Exceptions;
using Domain.TerminalScope.Models;
using Domain.TerminalScope.Specifications;
using Domain.TerminalScope.ValueObjects;

#endregion

namespace Business.CommonScope.Services;

public class TerminalSessionService : ITerminalSessionService
{
    private readonly IPersistenceContextFactory _persistenceContextFactory;


    public TerminalSessionService(IPersistenceContextFactory persistenceContextFactory)
    {
        if (persistenceContextFactory is null) throw new ArgumentNullException(nameof(persistenceContextFactory));

        _persistenceContextFactory = persistenceContextFactory;
    }

    public async Task<Terminal> ValidateTokenAsync(TerminalToken token)
    {
        var guardByIdSpec = new FindByTerminalTokenSpecification(
            token
        );

        Terminal terminal;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            terminal = await context.TerminalRepository.FirstByAsync(guardByIdSpec);
        }

        if (terminal is null) throw new TerminalTokenInvalidException("The terminal token is invalid.");

        if (terminal.IsTokenExpired(DateOnly.FromDateTime(DateTime.Today)))
            throw new TerminalTokenInvalidException("The terminal token is expired.");

        return terminal;
    }
}