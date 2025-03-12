using System;
using AutoMapper;
using FacilityAccessService.Business.UserScope.Models;
using FacilityAccessService.Business.UserScope.ValueObjects;
using FacilityAccessService.Persistence.UserScope.Mapping;
using KellermanSoftware.CompareNetObjects;

namespace Persistence.Tests.Mapping.Models
{
    public class UserMappingTest
    {
        private readonly IMapper _mapper;

        private readonly ICompareLogic _compare;


        public UserMappingTest()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<UserMapping>(); });
            _mapper = config.CreateMapper();
            
            _compare = new CompareLogic();
            _compare.Config.IgnoreObjectTypes = true;
        }

        [Fact]
        public void BusinessModel_User_To_PersistenceModel()
        {
            var businessModel = new User(Guid.NewGuid().ToString());

            var persistenceModel = _mapper.Map<FacilityAccessService.Persistence.UserScope.Models.User>(businessModel);

            
            var result = _compare.Compare(businessModel, persistenceModel);
            
            Assert.True(result.AreEqual, result.DifferencesString);
        }

        [Fact]
        public void PersistenceModel_User_To_BusinessModel()
        {
            var persistenceModel = new FacilityAccessService.Persistence.UserScope.Models.User()
            {
                Id = Guid.NewGuid().ToString(),
                Role = Role.Administrator
            };

            var businessModel = _mapper.Map<User>(persistenceModel);

            
            var result = _compare.Compare(persistenceModel, businessModel);
            
            Assert.True(result.AreEqual, result.DifferencesString);
        }
    }
}