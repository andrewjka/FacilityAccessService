using System;
using AutoMapper;
using FacilityAccessService.Business.FacilityScope.Models;
using FacilityAccessService.Persistence.FacilityScope.Mapping;


namespace Persistence.Tests.Mapping.Models
{
    public class FacilityMappingTest
    {
        private readonly IMapper _mapper;

        public FacilityMappingTest()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<FacilityMapping>(); });
            _mapper = config.CreateMapper();
        }

        [Fact]
        public void BusinessModel_Facility_To_PersistenceModel()
        {
            var businessFacility =
                new Facility(
                    name: "Checkpoint",
                    description: "Main entrance with facial recognition system and turnstiles."
                );

            var persistenceFacility =
                _mapper.Map<FacilityAccessService.Persistence.FacilityScope.Models.Facility>(businessFacility);

            Assert.Equal(businessFacility.Name, persistenceFacility.Name);
            Assert.Equal(businessFacility.Description, persistenceFacility.Description);
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

            Assert.Equal(persistenceModel.Name, businessModel.Name);
            Assert.Equal(persistenceModel.Description, businessModel.Description);
        }
    }
}