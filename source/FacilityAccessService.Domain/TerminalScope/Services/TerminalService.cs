using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.CommonScope.PersistenceContext;
using FacilityAccessService.Business.CommonScope.Specifications.Generic;
using FacilityAccessService.Business.TerminalScope.Actions;
using FacilityAccessService.Business.TerminalScope.Exceptions;
using FacilityAccessService.Business.TerminalScope.Models;
using FacilityAccessService.Business.TerminalScope.Services;
using FacilityAccessService.Business.TerminalScope.ValueObjects;
using FluentValidation;

namespace FacilityAccessService.Domain.TerminalScope.Services
{
    public class TerminalService : ITerminalService
    {
        private readonly IValidator<CreateTerminalModel> _createTerminalVL;
        private readonly IValidator<UpdateTerminalModel> _updateTerminalVL;
        private readonly IValidator<DeleteTerminalModel> _deleteTerminalVL;
        private readonly IValidator<Terminal> _terminalVL;

        private readonly IPersistenceContextFactory _persistenceContextFactory;


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

            this._createTerminalVL = createTerminalVl;
            this._updateTerminalVL = updateTerminalVl;
            this._deleteTerminalVL = deleteTerminalVl;
            this._terminalVL = terminalVl;
            this._persistenceContextFactory = persistenceContextFactory;
        }

        public async Task<Terminal> CreateTerminalAsync(
            CreateTerminalModel createTerminalModel
        )
        {
            _createTerminalVL.ValidateAndThrow(createTerminalModel);

            Terminal terminal = new Terminal(
                name: createTerminalModel.Name,
                token: TerminalToken.GenerateToken(),
                expiredTokenOn: createTerminalModel.ExpiredTokenOn
            );

            _terminalVL.ValidateAndThrow(terminal);


            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContext())
            {
                await context.TerminalRepository.CreateAsync(terminal);

                await context.CommitAsync();
            }

            return terminal;
        }

        public async Task<Terminal> UpdateTerminalAsync(UpdateTerminalModel updateTerminalModel)
        {
            _updateTerminalVL.ValidateAndThrow(updateTerminalModel);


            FindByGUIDSpecification<Terminal> findByGuidSpec = new FindByGUIDSpecification<Terminal>(
                updateTerminalModel.TerminalId
            );

            Terminal terminal;
            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContext())
            {
                terminal = await context.TerminalRepository.FirstByAsync(findByGuidSpec);
            }

            if (terminal is null)
            {
                throw new TerminalNotFoundException("The terminal with the specified id does not exist.");
            }


            if (updateTerminalModel.Name is not null)
            {
                terminal.ChangeName(updateTerminalModel.Name);
            }

            if (updateTerminalModel.ExpiredTokenOn is not null)
            {
                terminal.ChangeExpiredTokenOn((DateOnly)updateTerminalModel.ExpiredTokenOn);
            }

            _terminalVL.ValidateAndThrow(terminal);


            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContext())
            {
                await context.TerminalRepository.UpdateAsync(terminal);

                await context.CommitAsync();
            }

            return terminal;
        }

        public async Task DeleteTerminalAsync(DeleteTerminalModel deleteTerminalModel)
        {
            _deleteTerminalVL.ValidateAndThrow(deleteTerminalModel);


            FindByGUIDSpecification<Terminal> findByGuidSpec = new FindByGUIDSpecification<Terminal>(
                deleteTerminalModel.TerminalId
            );

            Terminal terminal;
            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContext())
            {
                terminal = await context.TerminalRepository.FirstByAsync(findByGuidSpec);
            }

            if (terminal is null)
            {
                throw new TerminalNotFoundException("The terminal with the specified id does not exist.");
            }


            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContext())
            {
                await context.TerminalRepository.DeleteAsync(terminal);

                await context.CommitAsync();
            }
        }
    }
}