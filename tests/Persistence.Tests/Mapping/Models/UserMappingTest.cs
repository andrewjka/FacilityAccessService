using System;
using AutoMapper;
using FacilityAccessService.Business.UserScope.Models;
using FacilityAccessService.Business.UserScope.ValueObjects;
using FacilityAccessService.Persistence.UserScope.Mapping;

namespace Persistence.Tests.Mapping.Models
{
    public class UserMappingTest
    {
        private readonly IMapper _mapper;

        public UserMappingTest()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<UserMapping>(); });

            _mapper = config.CreateMapper();
        }

        [Fact]
        public void BusinessModel_User_To_PersistenceModel()
        {
            var businessModel = new User(Guid.NewGuid().ToString());

            var persistenceModel = _mapper.Map<FacilityAccessService.Persistence.UserScope.Models.User>(businessModel);

            Assert.Equal(businessModel.Id, persistenceModel.Id);
            Assert.Equal(businessModel.Role, persistenceModel.Role);
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

            Assert.Equal(persistenceModel.Id, businessModel.Id);
            Assert.Equal(persistenceModel.Role, businessModel.Role);
        }
    }
}