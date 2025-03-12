using System;
using AutoMapper;
using FacilityAccessService.Business.TerminalScope.Models;
using FacilityAccessService.Business.TerminalScope.ValueObjects;
using FacilityAccessService.Persistence.TerminalScope.Mapping;
using KellermanSoftware.CompareNetObjects;

namespace Persistence.Tests.Mapping.Models
{
    public class TerminalMappingTest
    {
        private readonly IMapper _mapper;
        
        private readonly ICompareLogic _compare;


        public TerminalMappingTest()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<TerminalMapping>(); });
            _mapper = config.CreateMapper();
            
            _compare = new CompareLogic();
            _compare.Config.IgnoreObjectTypes = true;
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

            
            var result = _compare.Compare(businessModel, persistenceModel);
            
            Assert.True(result.AreEqual, result.DifferencesString);
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

            
            var result = _compare.Compare(persistenceModel, businessModel);

            Assert.True(result.AreEqual, result.DifferencesString);
        }
    }
}