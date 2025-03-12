using System;
using AutoMapper;
using FacilityAccessService.Business.AccessScope.Models;
using FacilityAccessService.Business.AccessScope.ValueObjects;
using FacilityAccessService.Persistence.AccessScope.Mapping;
using KellermanSoftware.CompareNetObjects;

namespace Persistence.Tests.Mapping.Models
{
    public class UserFacilityMappingTest
    {
        private readonly IMapper _mapper;

        private readonly ICompareLogic _compare;


        public UserFacilityMappingTest()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<UserFacilityMapping>(); });
            _mapper = config.CreateMapper();


            _compare = new CompareLogic();
            _compare.Config.IgnoreObjectTypes = true;
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


            var result = _compare.Compare(businessModel, persistenceModel);

            Assert.True(result.AreEqual, result.DifferencesString);
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


            var result = _compare.Compare(persistenceModel, businessModel);

            Assert.True(result.AreEqual, result.DifferencesString);
        }
    }
}