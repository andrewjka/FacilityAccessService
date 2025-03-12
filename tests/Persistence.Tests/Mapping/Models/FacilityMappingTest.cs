using System;
using AutoMapper;
using FacilityAccessService.Business.FacilityScope.Models;
using FacilityAccessService.Persistence.FacilityScope.Mapping;
using KellermanSoftware.CompareNetObjects;


namespace Persistence.Tests.Mapping.Models
{
    public class FacilityMappingTest
    {
        private readonly IMapper _mapper;
        private readonly ICompareLogic _compare;



        public FacilityMappingTest()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<FacilityMapping>(); });
            _mapper = config.CreateMapper();
            
            _compare = new CompareLogic();
            _compare.Config.IgnoreObjectTypes = true;
        }

        [Fact]
        public void BusinessModel_Facility_To_PersistenceModel()
        {
            var businessModel =
                new Facility(
                    name: "Checkpoint",
                    description: "Main entrance with facial recognition system and turnstiles."
                );

            var persistenceModel =
                _mapper.Map<FacilityAccessService.Persistence.FacilityScope.Models.Facility>(businessModel);

            
            var result = _compare.Compare(businessModel, persistenceModel);
            
            Assert.True(result.AreEqual, result.DifferencesString);
        }

        [Fact]
        public void PersistenceModel_Facility_To_BusinessModel()
        {
            var persistenceModel = new FacilityAccessService.Persistence.FacilityScope.Models.Facility()
            {
                Id = Guid.NewGuid(),
                Name = "Checkpoint",
                Description = "Main entrance with facial recognition system and turnstiles."
            };

            var businessModel = _mapper.Map<Facility>(persistenceModel);

            
            var result = _compare.Compare(persistenceModel, businessModel);

            Assert.True(result.AreEqual, result.DifferencesString);
        }
    }
}