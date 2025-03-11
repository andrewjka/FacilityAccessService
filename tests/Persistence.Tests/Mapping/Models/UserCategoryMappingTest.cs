using System;
using AutoMapper;
using FacilityAccessService.Business.AccessScope.Models;
using FacilityAccessService.Business.AccessScope.ValueObjects;
using FacilityAccessService.Persistence.AccessScope.Mapping;

namespace Persistence.Tests.Mapping.Models
{
    public class UserCategoryMappingTest
    {
        private readonly IMapper _mapper;

        public UserCategoryMappingTest()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<UserCategoryMapping>(); });
            _mapper = config.CreateMapper();
        }

        [Fact]
        public void BusinessModel_UserCategory_To_PersistenceModel()
        {
            AccessPeriod accessPeriod = new AccessPeriod(
                startDate: DateOnly.MinValue,
                endDate: DateOnly.MaxValue
            );

            var businessModel = new UserCategory(
                userId: Guid.NewGuid().ToString(),
                categoryId: Guid.NewGuid(),
                accessPeriod: accessPeriod
            );

            var persistenceModel =
                _mapper.Map<FacilityAccessService.Persistence.AccessScope.Models.UserCategory>(businessModel);

            Assert.Equal(businessModel.UserId, persistenceModel.UserId);
            Assert.Equal(businessModel.CategoryId, persistenceModel.CategoryId);
            Assert.Equal(businessModel.AccessPeriod, persistenceModel.AccessPeriod);
        }

        [Fact]
        public void PersistenceModel_UserCategory_To_BusinessModel()
        {
            AccessPeriod accessPeriod = new AccessPeriod(
                startDate: DateOnly.MinValue,
                endDate: DateOnly.MaxValue
            );

            var persistenceModel = new FacilityAccessService.Persistence.AccessScope.Models.UserCategory()
            {
                UserId = Guid.NewGuid().ToString(),
                CategoryId = Guid.NewGuid(),
                AccessPeriod = accessPeriod
            };

            var businessModel = _mapper.Map<UserCategory>(persistenceModel);

            Assert.Equal(persistenceModel.UserId, businessModel.UserId);
            Assert.Equal(persistenceModel.CategoryId, businessModel.CategoryId);
            Assert.Equal(persistenceModel.AccessPeriod, businessModel.AccessPeriod);
        }
    }
}