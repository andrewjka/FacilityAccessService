using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FacilityAccessService.Business.FacilityScope.Models;
using FacilityAccessService.Persistence.FacilityScope.Mapping;
using KellermanSoftware.CompareNetObjects;

namespace Persistence.Tests.Mapping.Models
{
    public class CategoryMappingTest
    {
        private readonly IMapper _mapper;
        
        private readonly ICompareLogic _compare;
        

        public CategoryMappingTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CategoryMapping>();
                cfg.AddProfile<FacilityMapping>();
            });
            _mapper = config.CreateMapper();
            
            _compare = new CompareLogic();
            _compare.Config.IgnoreObjectTypes = true;
        }

        [Fact]
        public void BusinessModel_Category_To_PersistenceModel()
        {
            var businessFacilities = new HashSet<Facility>
            {
                new Facility("Checkpoint", "Main entrance with facial recognition system and turnstiles."),
                new Facility("Server Room", "Secure area with equipment for data processing and storage.")
            };
            var businessModel = new Category(
                name: "Facilities",
                facilities: businessFacilities
            );

            var persistenceModel =
                _mapper.Map<FacilityAccessService.Persistence.FacilityScope.Models.Category>(businessModel);

            
            
            var result = _compare.Compare(businessModel, persistenceModel);
            
            Assert.True(result.AreEqual, result.DifferencesString);
        }

        [Fact]
        public void PersistenceModel_Category_To_BusinessModel()
        {
            var persistenceFacilities = new HashSet<FacilityAccessService.Persistence.FacilityScope.Models.Facility>
            {
                new FacilityAccessService.Persistence.FacilityScope.Models.Facility()
                {
                    Id = Guid.NewGuid(),
                    Name = "Checkpoint",
                    Description = "Main entrance with facial recognition system and turnstiles."
                },
                new FacilityAccessService.Persistence.FacilityScope.Models.Facility()
                {
                    Id = Guid.NewGuid(),
                    Name = "Server Room",
                    Description = "Secure area with equipment for data processing and storage."
                }
            };
            var persistenceModel = new FacilityAccessService.Persistence.FacilityScope.Models.Category()
            {
                Id = Guid.NewGuid(),
                Name = "Facilities",
                Facilities = persistenceFacilities.ToList()
            };

            var businessModel = _mapper.Map<Category>(persistenceModel);

            
            var result = _compare.Compare(persistenceModel, businessModel);

            Assert.True(result.AreEqual, result.DifferencesString);
        }
    }
}