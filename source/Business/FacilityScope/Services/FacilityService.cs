#region

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Domain.CommonScope.PersistenceContext;
using Domain.CommonScope.Specification;
using Domain.CommonScope.Specifications.Generic;
using Domain.FacilityScope.Actions;
using Domain.FacilityScope.Exceptions;
using Domain.FacilityScope.Models;
using Domain.FacilityScope.Services;
using FluentValidation;

#endregion

namespace Business.FacilityScope.Services;

public class FacilityService : IFacilityService
{
    private readonly IValidator<CreateFacilityModel> _createFacilityVl;
    private readonly IValidator<DeleteFacilityModel> _deleteFacilityVL;
    private readonly IValidator<Facility> _facilityVl;

    private readonly IPersistenceContextFactory _persistenceContextFactory;
    private readonly IValidator<UpdateFacilityModel> _updateFacilityVL;

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

        _createFacilityVl = createFacilityVL;
        _updateFacilityVL = updateFacilityVl;
        _deleteFacilityVL = deleteFacilityVl;
        _facilityVl = facilityVL;
        _persistenceContextFactory = persistenceContextFactory;
    }


    public async Task<Facility> CreateFacilityAsync(CreateFacilityModel createFacilityModel)
    {
        _createFacilityVl.ValidateAndThrow(createFacilityModel);


        var facility = new Facility(
            createFacilityModel.Name,
            createFacilityModel.Description
        );

        _facilityVl.ValidateAndThrow(facility);


        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
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
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            facility = await context.FacilityRepository.FirstByAsync(specification);
        }

        return facility;
    }

    public async Task<ReadOnlyCollection<Facility>> GetFacilitiesAsync(Specification<Facility> specification)
    {
        ReadOnlyCollection<Facility> facilities;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            facilities = await context.FacilityRepository.SelectByAsync(specification);
        }

        return facilities;
    }

    public async Task<Facility> UpdateFacilityAsync(UpdateFacilityModel updateFacilityModel)
    {
        _updateFacilityVL.ValidateAndThrow(updateFacilityModel);


        var findByGuidSpec = new FindByGUIDSpecification<Facility>(
            updateFacilityModel.FacilityId
        );

        Facility facility;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            facility = await context.FacilityRepository.FirstByAsync(findByGuidSpec);
        }

        if (facility is null) throw new FacilityNotFoundException("The facility with the specified id does not exist.");


        if (updateFacilityModel.Name is not null) facility.ChangeName(updateFacilityModel.Name);

        if (updateFacilityModel.Description is not null) facility.ChangeDescription(updateFacilityModel.Description);

        _facilityVl.ValidateAndThrow(facility);


        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
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


        var findByGuidSpec = new FindByGUIDSpecification<Facility>(
            deleteFacilityModel.FacilityId
        );

        Facility facility;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            facility = await context.FacilityRepository.FirstByAsync(findByGuidSpec);
        }

        if (facility is null) throw new FacilityNotFoundException("The facility with the specified id does not exist.");


        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            await context.FacilityRepository.DeleteAsync(facility);

            await context.ApplyChangesAsync();
            await context.CommitAsync();
        }
    }
}