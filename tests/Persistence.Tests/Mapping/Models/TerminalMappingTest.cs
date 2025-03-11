using System;
using AutoMapper;
using FacilityAccessService.Business.TerminalScope.Models;
using FacilityAccessService.Business.TerminalScope.ValueObjects;
using FacilityAccessService.Persistence.TerminalScope.Mapping;

namespace Persistence.Tests.Mapping.Models
{
    public class TerminalMappingTest
    {
        private readonly IMapper _mapper;

        public TerminalMappingTest()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<TerminalMapping>(); });

            _mapper = config.CreateMapper();
        }

        [Fact]
        public void BusinessModel_Terminal_To_PersistenceModel()
        {
            var businessModel = new Terminal(
                name: Guid.NewGuid().ToString(),
                token: TerminalToken.GenerateToken(),
                expiredTokenOn: DateOnly.FromDateTime(DateTime.Today)
            );

            var persistenceModel =
                _mapper.Map<FacilityAccessService.Persistence.TerminalScope.Models.Terminal>(businessModel);

            Assert.Equal(businessModel.Id, persistenceModel.Id);
            Assert.Equal(businessModel.Name, persistenceModel.Name);
            Assert.Equal(businessModel.Token, persistenceModel.Token);
            Assert.Equal(businessModel.ExpiredTokenOn, persistenceModel.ExpiredTokenOn);
        }

        [Fact]
        public void PersistenceModel_Terminal_To_BusinessModel()
        {
            var persistenceModel = new FacilityAccessService.Persistence.TerminalScope.Models.Terminal()
            {
                Name = Guid.NewGuid().ToString(),
                Token = TerminalToken.GenerateToken(),
                ExpiredTokenOn = DateOnly.FromDateTime(DateTime.Today)
            };

            var businessModel = _mapper.Map<Terminal>(persistenceModel);

            Assert.Equal(persistenceModel.Id, businessModel.Id);
            Assert.Equal(persistenceModel.Name, businessModel.Name);
            Assert.Equal(persistenceModel.Token, businessModel.Token);
            Assert.Equal(persistenceModel.ExpiredTokenOn, businessModel.ExpiredTokenOn);
        }
    }
}