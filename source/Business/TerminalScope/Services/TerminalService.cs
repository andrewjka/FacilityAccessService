#region

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Domain.CommonScope.PersistenceContext;
using Domain.CommonScope.Specification;
using Domain.CommonScope.Specifications.Generic;
using Domain.TerminalScope.Actions;
using Domain.TerminalScope.Exceptions;
using Domain.TerminalScope.Models;
using Domain.TerminalScope.Services;
using Domain.TerminalScope.ValueObjects;
using FluentValidation;

#endregion

namespace Business.TerminalScope.Services;

public class TerminalService : ITerminalService
{
    private readonly IValidator<CreateTerminalModel> _createTerminalVL;
    private readonly IValidator<DeleteTerminalModel> _deleteTerminalVL;

    private readonly IPersistenceContextFactory _persistenceContextFactory;
    private readonly IValidator<Terminal> _terminalVL;
    private readonly IValidator<UpdateTerminalModel> _updateTerminalVL;


    public TerminalService(
        IValidator<CreateTerminalModel> createTerminalVl,
        IValidator<UpdateTerminalModel> updateTerminalVl,
        IValidator<DeleteTerminalModel> deleteTerminalVl,
        IValidator<Terminal> terminalVl,
        IPersistenceContextFactory persistenceContextFactory
    )
    {
        if (createTerminalVl is null) throw new ArgumentNullException(nameof(createTerminalVl));
        if (updateTerminalVl is null) throw new ArgumentNullException(nameof(updateTerminalVl));
        if (deleteTerminalVl is null) throw new ArgumentNullException(nameof(deleteTerminalVl));
        if (terminalVl is null) throw new ArgumentNullException(nameof(terminalVl));
        if (persistenceContextFactory is null) throw new ArgumentNullException(nameof(persistenceContextFactory));

        _createTerminalVL = createTerminalVl;
        _updateTerminalVL = updateTerminalVl;
        _deleteTerminalVL = deleteTerminalVl;
        _terminalVL = terminalVl;
        _persistenceContextFactory = persistenceContextFactory;
    }

    public async Task<Terminal> CreateTerminalAsync(
        CreateTerminalModel createTerminalModel
    )
    {
        _createTerminalVL.ValidateAndThrow(createTerminalModel);

        var terminal = new Terminal(
            createTerminalModel.Name,
            TerminalToken.GenerateToken(),
            createTerminalModel.ExpiredTokenOn
        );

        _terminalVL.ValidateAndThrow(terminal);


        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            await context.TerminalRepository.CreateAsync(terminal);

            await context.ApplyChangesAsync();
            await context.CommitAsync();
        }

        return terminal;
    }

    public async Task<Terminal> GetTerminalAsync(Specification<Terminal> specification)
    {
        Terminal terminal;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            terminal = await context.TerminalRepository.FirstByAsync(specification);
        }

        return terminal;
    }

    public async Task<ReadOnlyCollection<Terminal>> GetTerminalsAsync(Specification<Terminal> specification)
    {
        ReadOnlyCollection<Terminal> terminals;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            terminals = await context.TerminalRepository.SelectByAsync(specification);
        }

        return terminals;
    }

    public async Task<Terminal> UpdateTerminalAsync(UpdateTerminalModel updateTerminalModel)
    {
        _updateTerminalVL.ValidateAndThrow(updateTerminalModel);


        var findByGuidSpec = new FindByGUIDSpecification<Terminal>(
            updateTerminalModel.TerminalId
        );

        Terminal terminal;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            terminal = await context.TerminalRepository.FirstByAsync(findByGuidSpec);
        }

        if (terminal is null) throw new TerminalNotFoundException("The terminal with the specified id does not exist.");


        if (updateTerminalModel.Name is not null) terminal.ChangeName(updateTerminalModel.Name);

        if (updateTerminalModel.ExpiredTokenOn is not null)
            terminal.ChangeExpiredTokenOn((DateOnly)updateTerminalModel.ExpiredTokenOn);

        _terminalVL.ValidateAndThrow(terminal);


        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            await context.TerminalRepository.UpdateAsync(terminal);

            await context.ApplyChangesAsync();
            await context.CommitAsync();
        }

        return terminal;
    }

    public async Task DeleteTerminalAsync(DeleteTerminalModel deleteTerminalModel)
    {
        _deleteTerminalVL.ValidateAndThrow(deleteTerminalModel);


        var findByGuidSpec = new FindByGUIDSpecification<Terminal>(
            deleteTerminalModel.TerminalId
        );

        Terminal terminal;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            terminal = await context.TerminalRepository.FirstByAsync(findByGuidSpec);
        }

        if (terminal is null) throw new TerminalNotFoundException("The terminal with the specified id does not exist.");


        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            await context.TerminalRepository.DeleteAsync(terminal);

            await context.ApplyChangesAsync();
            await context.CommitAsync();
        }
    }
}