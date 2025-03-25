#region

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FacilityAccessService.Business.CommonScope.PersistenceContext;
using FacilityAccessService.Business.CommonScope.Specification;
using FacilityAccessService.Business.CommonScope.Specifications.Generic;
using FacilityAccessService.Business.FacilityScope.Actions;
using FacilityAccessService.Business.FacilityScope.Exceptions;
using FacilityAccessService.Business.FacilityScope.Models;
using FacilityAccessService.Business.FacilityScope.Services;
using FluentValidation;

#endregion

namespace FacilityAccessService.Domain.FacilityScope.Services
{
    public class FacilityService : IFacilityService
    {
        private readonly IValidator<CreateFacilityModel> _createFacilityVl;
        private readonly IValidator<UpdateFacilityModel> _updateFacilityVL;
        private readonly IValidator<DeleteFacilityModel> _deleteFacilityVL;
        private readonly IValidator<Facility> _facilityVl;

        private readonly IPersistenceContextFactory _persistenceContextFactory;

        public FacilityService(
            IValidator<CreateFacilityModel> createFacilityVL,
            IValidator<UpdateFacilityModel> updateFacilityVl,
            IValidator<DeleteFacilityModel> deleteFacilityVl,
            IValidator<Facility> facilityVL,
            IPersistenceContextFactory persistenceContextFactory
        )
        {
            if (createFacilityVL is null) throw new ArgumentNullException(nameof(createFacilityVL));
            if (updateFacilityVl is null) throw new ArgumentNullException(nameof(updateFacilityVl));
            if (deleteFacilityVl is null) throw new ArgumentNullException(nameof(deleteFacilityVl));
            if (facilityVL is null) throw new ArgumentNullException(nameof(facilityVL));

            if (persistenceContextFactory is null) throw new ArgumentNullException(nameof(persistenceContextFactory));

            this._createFacilityVl = createFacilityVL;
            this._updateFacilityVL = updateFacilityVl;
            this._deleteFacilityVL = deleteFacilityVl;
            this._facilityVl = facilityVL;
            this._persistenceContextFactory = persistenceContextFactory;
        }


        public async Task<Facility> CreateFacilityAsync(CreateFacilityModel createFacilityModel)
        {
            _createFacilityVl.ValidateAndThrow(createFacilityModel);


            Facility facility = new Facility(
                name: createFacilityModel.Name,
                description: createFacilityModel.Description
            );

            _facilityVl.ValidateAndThrow(facility);


            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                await context.FacilityRepository.CreateAsync(facility);

                await context.ApplyChangesAsync();
                await context.CommitAsync();
            }

            return facility;
        }

        public async Task<Facility> GetFacilityAsync(Specification<Facility> specification)
        {
            Facility facility;
            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                facility = await context.FacilityRepository.FirstByAsync(specification);
            }

            return facility;
        }

        public async Task<ReadOnlyCollection<Facility>> GetFacilitiesAsync(Specification<Facility> specification)
        {
            ReadOnlyCollection<Facility> facilities;
            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                facilities = await context.FacilityRepository.SelectByAsync(specification);
            }

            return facilities;
        }

        public async Task<Facility> UpdateFacilityAsync(UpdateFacilityModel updateFacilityModel)
        {
            _updateFacilityVL.ValidateAndThrow(updateFacilityModel);


            FindByGUIDSpecification<Facility> findByGuidSpec = new FindByGUIDSpecification<Facility>(
                guid: updateFacilityModel.FacilityId
            );

            Facility facility;
            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                facility = await context.FacilityRepository.FirstByAsync(findByGuidSpec);
            }

            if (facility is null)
            {
                throw new FacilityNotFoundException("The facility with the specified id does not exist.");
            }


            if (updateFacilityModel.Name is not null)
            {
                facility.ChangeName(updateFacilityModel.Name);
            }

            if (updateFacilityModel.Description is not null)
            {
                facility.ChangeDescription(updateFacilityModel.Description);
            }

            _facilityVl.ValidateAndThrow(facility);


            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                await context.FacilityRepository.UpdateAsync(facility);

                await context.ApplyChangesAsync();
                await context.CommitAsync();
            }

            return facility;
        }

        public async Task DeleteFacilityAsync(DeleteFacilityModel deleteFacilityModel)
        {
            _deleteFacilityVL.ValidateAndThrow(deleteFacilityModel);


            FindByGUIDSpecification<Facility> findByGuidSpec = new FindByGUIDSpecification<Facility>(
                deleteFacilityModel.FacilityId
            );

            Facility facility;
            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                facility = await context.FacilityRepository.FirstByAsync(findByGuidSpec);
            }

            if (facility is null)
            {
                throw new FacilityNotFoundException("The facility with the specified id does not exist.");
            }


            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                await context.FacilityRepository.DeleteAsync(facility);

                await context.ApplyChangesAsync();
                await context.CommitAsync();
            }
        }
    }
}