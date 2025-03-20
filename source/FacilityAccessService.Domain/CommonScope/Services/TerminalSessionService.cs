using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.CommonScope.PersistenceContext;
using FacilityAccessService.Business.CommonScope.Services;
using FacilityAccessService.Business.TerminalScope.Exceptions;
using FacilityAccessService.Business.TerminalScope.Models;
using FacilityAccessService.Business.TerminalScope.Specifications;
using FacilityAccessService.Business.TerminalScope.ValueObjects;


namespace FacilityAccessService.Domain.CommonScope.Services
{
    public class TerminalSessionService : ITerminalSessionService
    {
        private readonly IPersistenceContextFactory _persistenceContextFactory;


        public TerminalSessionService(IPersistenceContextFactory persistenceContextFactory)
        {
            if (persistenceContextFactory is null) throw new ArgumentNullException(nameof(persistenceContextFactory));

            this._persistenceContextFactory = persistenceContextFactory;
        }

        public async Task<Terminal> ValidateTokenAsync(TerminalToken token)
        {
            FindByTerminalTokenSpecification guardByIdSpec = new FindByTerminalTokenSpecification(
                token: token
            );

            Terminal terminal;
            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                terminal = await context.TerminalRepository.FirstByAsync(guardByIdSpec);
            }

            if (terminal is null)
            {
                throw new TerminalTokenInvalidException("The terminal token is invalid.");
            }

            if (terminal.IsTokenExpired(DateOnly.FromDateTime(DateTime.Today)))
            {
                throw new TerminalTokenInvalidException("The terminal token is expired.");
            }

            return terminal;
        }
    }
}