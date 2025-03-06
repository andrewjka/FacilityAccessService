using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.CommonScope.Specifications.Generic;
using FacilityAccessService.Business.TerminalScope.Actions;
using FacilityAccessService.Business.TerminalScope.Exceptions;
using FacilityAccessService.Business.TerminalScope.Models;
using FacilityAccessService.Business.TerminalScope.Repositories;
using FacilityAccessService.Business.TerminalScope.Services;
using FacilityAccessService.Business.TerminalScope.ValueObjects;
using FluentValidation;

namespace FacilityAccessService.Domain.TerminalScope
{
    public class TerminalService : ITerminalService
    {
        private IValidator<CreateTerminalModel> _createTerminalVL;
        private IValidator<UpdateTerminalModel> _updateTerminalVL;
        private IValidator<DeleteTerminalModel> _deleteTerminalVL;
        private IValidator<Terminal> _terminalVL;

        private ITerminalRepository _terminalRepository;


        public TerminalService(
            IValidator<CreateTerminalModel> createTerminalVl,
            IValidator<UpdateTerminalModel> updateTerminalVl,
            IValidator<DeleteTerminalModel> deleteTerminalVl,
            IValidator<Terminal> terminalVl,
            ITerminalRepository terminalRepository
        )
        {
            if (createTerminalVl is null) throw new ArgumentNullException(nameof(createTerminalVl));
            if (updateTerminalVl is null) throw new ArgumentNullException(nameof(updateTerminalVl));
            if (deleteTerminalVl is null) throw new ArgumentNullException(nameof(deleteTerminalVl));
            if (terminalVl is null) throw new ArgumentNullException(nameof(terminalVl));
            if (terminalRepository is null) throw new ArgumentNullException(nameof(terminalRepository));

            this._createTerminalVL = createTerminalVl;
            this._updateTerminalVL = updateTerminalVl;
            this._deleteTerminalVL = deleteTerminalVl;
            this._terminalVL = terminalVl;
            this._terminalRepository = terminalRepository;
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

            await _terminalRepository.CreateAsync(terminal);

            return terminal;
        }

        public async Task<Terminal> UpdateTerminalAsync(UpdateTerminalModel updateTerminalModel)
        {
            _updateTerminalVL.ValidateAndThrow(updateTerminalModel);


            FirstByIdSpecification<Terminal> firstByIdSpecification = new FirstByIdSpecification<Terminal>(
                updateTerminalModel.Uid
            );

            Terminal terminal = await _terminalRepository.FirstByAsync(firstByIdSpecification);
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


            await _terminalRepository.UpdateAsync(terminal);

            return terminal;
        }

        public async Task DeleteTerminalAsync(DeleteTerminalModel deleteTerminalModel)
        {
            _deleteTerminalVL.ValidateAndThrow(deleteTerminalModel);


            FirstByIdSpecification<Terminal> firstByIdSpecification = new FirstByIdSpecification<Terminal>(
                deleteTerminalModel.Uid
            );

            Terminal terminal = await _terminalRepository.FirstByAsync(firstByIdSpecification);
            if (terminal is null)
            {
                throw new TerminalNotFoundException("The terminal with the specified id does not exist.");
            }

            await _terminalRepository.DeleteAsync(terminal);
        }
    }
}