#region

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Domain.AccessScope.Actions;
using Domain.AccessScope.Exceptions;
using Domain.AccessScope.Models;
using Domain.AccessScope.Services;
using Domain.AccessScope.Specifications;
using Domain.CommonScope.PersistenceContext;
using Domain.CommonScope.Specification;
using Domain.CommonScope.Specifications.Generic;
using Domain.FacilityScope.Exceptions;
using Domain.FacilityScope.Models;
using Domain.UserScope.Exceptions;
using Domain.UserScope.Models;
using Domain.UserScope.Specifications;
using FluentValidation;

#endregion

namespace Business.AccessScope.Services;

public class AccessFacilityService : IAccessFacilityService
{
    private readonly IValidator<GrantAccessFacilityModel> _grantAccessVL;

    private readonly IPersistenceContextFactory _persistenceContextFactory;
    private readonly IValidator<RevokeAccessFacilityModel> _revokeAccessVL;
    private readonly IValidator<UpdateAccessFacilityModel> _updateAccessVL;
    private readonly IValidator<UserFacility> _userFacilityVL;


    public AccessFacilityService(
        IValidator<GrantAccessFacilityModel> grantAccessVL,
        IValidator<RevokeAccessFacilityModel> revokeAccessVL,
        IValidator<UpdateAccessFacilityModel> updateAccessVL,
        IValidator<UserFacility> userFacilityVL,
        IPersistenceContextFactory persistenceContextFactory
    )
    {
        if (grantAccessVL is null) throw new ArgumentNullException(nameof(grantAccessVL));
        if (revokeAccessVL is null) throw new ArgumentNullException(nameof(revokeAccessVL));
        if (updateAccessVL is null) throw new ArgumentNullException(nameof(updateAccessVL));
        if (userFacilityVL is null) throw new ArgumentNullException(nameof(userFacilityVL));

        if (persistenceContextFactory is null) throw new ArgumentNullException(nameof(persistenceContextFactory));

        _grantAccessVL = grantAccessVL;
        _revokeAccessVL = revokeAccessVL;
        _updateAccessVL = updateAccessVL;
        _userFacilityVL = userFacilityVL;
        _persistenceContextFactory = persistenceContextFactory;
    }


    public async Task GrantAccessAsync(GrantAccessFacilityModel grantAccessModel)
    {
        _grantAccessVL.ValidateAndThrow(grantAccessModel);


        var userByIdSpec = new FindByIdSpecification(
            grantAccessModel.UserId
        );

        User user;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            user = await context.UserRepository.FirstByAsync(userByIdSpec);
        }

        if (user is null) throw new UserNotFoundException("The user with the specified id does not exist.");


        var facilityByGuidSpecification = new FindByGUIDSpecification<Facility>(
            grantAccessModel.FacilityId
        );

        Facility facility;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            facility = await context.FacilityRepository.FirstByAsync(facilityByGuidSpecification);
        }

        if (facility is null) throw new FacilityNotFoundException("The facility with the specified id does not exist.");


        var userFacility = new UserFacility(
            grantAccessModel.UserId,
            grantAccessModel.FacilityId,
            grantAccessModel.AccessPeriod
        );

        _userFacilityVL.ValidateAndThrow(userFacility);


        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            await context.UserFacilityRepository.CreateAsync(userFacility);

            await context.ApplyChangesAsync();
            await context.CommitAsync();
        }
    }

    public async Task RevokeAccessAsync(RevokeAccessFacilityModel revokeAccessModel)
    {
        _revokeAccessVL.ValidateAndThrow(revokeAccessModel);


        var findActiveUserFacilitySpec = new FindUserFacilitySpecification(
            revokeAccessModel.UserId,
            revokeAccessModel.FacilityId
        );

        UserFacility userFacility;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            userFacility = await context.UserFacilityRepository.FirstByAsync(findActiveUserFacilitySpec);
        }

        if (userFacility is null) throw new UserFacilityNotFoundException("There is no such access to the facility.");


        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            await context.UserFacilityRepository.DeleteAsync(userFacility);

            await context.ApplyChangesAsync();
            await context.CommitAsync();
        }
    }

    public async Task UpdateAccessAsync(UpdateAccessFacilityModel updateAccessModel)
    {
        _updateAccessVL.ValidateAndThrow(updateAccessModel);


        var findActiveUserFacilitySpec = new FindUserFacilitySpecification(
            updateAccessModel.UserId,
            updateAccessModel.FacilityId
        );

        UserFacility userFacility;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            userFacility = await context.UserFacilityRepository.FirstByAsync(findActiveUserFacilitySpec);
        }

        if (userFacility is null) throw new UserFacilityNotFoundException("There is no such access to the facility.");

        if (updateAccessModel.AccessPeriod is not null) userFacility.ChangeAccessPeriod(updateAccessModel.AccessPeriod);

        _userFacilityVL.ValidateAndThrow(userFacility);


        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            await context.UserFacilityRepository.UpdateAsync(userFacility);

            await context.ApplyChangesAsync();
            await context.CommitAsync();
        }
    }

    public async Task<UserFacilityDto> GetAccessAsync(Specification<UserFacility> specification)
    {
        UserFacility userFacility;
        User user;
        Facility facility;

        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            userFacility = await context.UserFacilityRepository.FirstByAsync(specification);

            user = await context.UserRepository.FirstByAsync(new FindByIdSpecification(userFacility.UserId));
            facility = await context.FacilityRepository.FirstByAsync(
                new FindByGUIDSpecification<Facility>(userFacility.FacilityId)
            );
        }

        return new UserFacilityDto(user, facility, userFacility.AccessPeriod);
    }

    public async Task<ReadOnlyCollection<UserFacilityDto>> GetAccessesAsync(
        Specification<UserFacility> specification
    )
    {
        List<UserFacilityDto> _userFacilities = new List<UserFacilityDto>();
        
        ReadOnlyCollection<UserFacility> userFacilities;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            userFacilities = await context.UserFacilityRepository.SelectByAsync(specification);
        }
        
        foreach (var userFacility in userFacilities)
        {
            User user;
            Facility facility;
            
            await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                user = await context.UserRepository.FirstByAsync(new FindByIdSpecification(userFacility.UserId));
                facility = await context.FacilityRepository.FirstByAsync(
                    new FindByGUIDSpecification<Facility>(userFacility.FacilityId)
                );
            }
            
            _userFacilities.Add(new UserFacilityDto(user, facility, userFacility.AccessPeriod));
        }

        return _userFacilities.AsReadOnly();
    }
}