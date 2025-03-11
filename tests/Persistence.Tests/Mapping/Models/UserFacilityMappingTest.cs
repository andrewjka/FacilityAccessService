using System;
using AutoMapper;
using FacilityAccessService.Business.AccessScope.Models;
using FacilityAccessService.Business.AccessScope.ValueObjects;
using FacilityAccessService.Persistence.AccessScope.Mapping;

namespace Persistence.Tests.Mapping.Models
{
    public class UserFacilityMappingTest
    {
        private readonly IMapper _mapper;

        public UserFacilityMappingTest()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<UserFacilityMapping>(); });
            _mapper = config.CreateMapper();
        }

        [Fact]
        public void BusinessModel_UserFacility_To_PersistenceModel()
        {
            AccessPeriod accessPeriod = new AccessPeriod(
                startDate: DateOnly.MinValue,
                endDate: DateOnly.MaxValue
            );

            var businessModel = new UserFacility(
                userId: Guid.NewGuid().ToString(),
                facilityId: Guid.NewGuid(),
                accessPeriod: accessPeriod
            );

            var persistenceModel =
                _mapper.Map<FacilityAccessService.Persistence.AccessScope.Models.UserFacility>(businessModel);

            Assert.Equal(businessModel.UserId, persistenceModel.UserId);
            Assert.Equal(businessModel.FacilityId, persistenceModel.FacilityId);
            Assert.Equal(businessModel.AccessPeriod, persistenceModel.AccessPeriod);
        }

        [Fact]
        public void PersistenceModel_UserFacility_To_BusinessModel()
        {
            AccessPeriod accessPeriod = new AccessPeriod(
                startDate: DateOnly.MinValue,
                endDate: DateOnly.MaxValue
            );

            var persistenceModel = new FacilityAccessService.Persistence.AccessScope.Models.UserFacility()
            {
                UserId = Guid.NewGuid().ToString(),
                FacilityId = Guid.NewGuid(),
                AccessPeriod = accessPeriod
            };

            var businessModel = _mapper.Map<UserFacility>(persistenceModel);

            Assert.Equal(persistenceModel.UserId, businessModel.UserId);
            Assert.Equal(persistenceModel.FacilityId, businessModel.FacilityId);
            Assert.Equal(persistenceModel.AccessPeriod, businessModel.AccessPeriod);
        }
    }
}