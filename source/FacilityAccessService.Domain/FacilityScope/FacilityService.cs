using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.CommonScope.Specifications.Generic;
using FacilityAccessService.Business.FacilityScope.Actions;
using FacilityAccessService.Business.FacilityScope.Exceptions;
using FacilityAccessService.Business.FacilityScope.Models;
using FacilityAccessService.Business.FacilityScope.Repositories;
using FacilityAccessService.Business.FacilityScope.Services;
using FluentValidation;

namespace FacilityAccessService.Domain.FacilityScope
{
    public class FacilityService : IFacilityService
    {
        private IValidator<CreateFacilityModel> _createFacilityVl;
        private IValidator<UpdateFacilityModel> _updateFacilityVL;
        private IValidator<DeleteFacilityModel> _deleteFacilityVL;
        private IValidator<Facility> _facilityVl;

        private IFacilityRepository _facilityRepository;


        public FacilityService(
            IValidator<CreateFacilityModel> createFacilityVL,
            IValidator<UpdateFacilityModel> updateFacilityVl,
            IValidator<DeleteFacilityModel> deleteFacilityVl,
            IValidator<Facility> facilityVL,
            IFacilityRepository facilityRepository
        )
        {
            if (createFacilityVL is null) throw new ArgumentNullException(nameof(createFacilityVL));
            if (updateFacilityVl is null) throw new ArgumentNullException(nameof(updateFacilityVl));
            if (deleteFacilityVl is null) throw new ArgumentNullException(nameof(deleteFacilityVl));
            if (facilityVL is null) throw new ArgumentNullException(nameof(facilityVL));
            
            if (facilityRepository is null) throw new ArgumentNullException(nameof(facilityRepository));

            this._createFacilityVl = createFacilityVL;
            this._updateFacilityVL = updateFacilityVl;
            this._deleteFacilityVL = deleteFacilityVl;
            this._facilityVl = facilityVL;
            this._facilityRepository = facilityRepository;
        }


        public async Task<Facility> CreateFacilityAsync(CreateFacilityModel createFacilityModel)
        {
            _createFacilityVl.ValidateAndThrow(createFacilityModel);


            Facility facility = new Facility(
                name: createFacilityModel.Name,
                description: createFacilityModel.Description
            );

            _facilityVl.ValidateAndThrow(facility);


            await _facilityRepository.CreateAsync(facility);

            return facility;
        }

        public async Task<Facility> UpdateFacilityAsync(UpdateFacilityModel updateFacilityModel)
        {
            _updateFacilityVL.ValidateAndThrow(updateFacilityModel);


            FirstByIdSpecification<Facility> firstByIdSpecification = new FirstByIdSpecification<Facility>(
                guid: updateFacilityModel.FacilityId
            );

            Facility facility = await _facilityRepository.FirstByAsync(firstByIdSpecification);
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


            await _facilityRepository.UpdateAsync(facility);

            return facility;
        }

        public async Task DeleteFacilityAsync(DeleteFacilityModel deleteFacilityModel)
        {
            _deleteFacilityVL.ValidateAndThrow(deleteFacilityModel);
            
            
            FirstByIdSpecification<Facility> firstByIdSpecification = new FirstByIdSpecification<Facility>(
                deleteFacilityModel.FacilityId
            );

            Facility category = await _facilityRepository.FirstByAsync(firstByIdSpecification);
            if (category is null)
            {
                throw new FacilityNotFoundException("The facility with the specified id does not exist.");
            }


            await _facilityRepository.DeleteAsync(category);
        }
    }
}