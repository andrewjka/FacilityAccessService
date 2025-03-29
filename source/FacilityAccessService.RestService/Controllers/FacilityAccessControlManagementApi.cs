/*
 * Facility Access Service API
 *
 * The service an access control system for facilities within the enterprise territory.
 *
 * The version of the OpenAPI document: 1.0.0
 *
 * Generated by: https://openapi-generator.tech
 */

#region

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using FacilityAccessService.Business.AccessScope.Actions;
using FacilityAccessService.Business.AccessScope.Specifications;
using FacilityAccessService.Business.AccessScope.ValueObjects;
using FacilityAccessService.Domain.Secure.AccessScope.Interfaces;
using FacilityAccessService.RestService.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

#endregion

namespace FacilityAccessService.RestService.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class FacilityAccessControlManagementApiController : ControllerBase
    {
        private readonly IAccessFacilityServiceSecure _service;

        private readonly IMapper _mapper;


        public FacilityAccessControlManagementApiController(IAccessFacilityServiceSecure service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }


        /// <summary>
        /// Gets a list of facilities to which the user has access.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="take"></param>
        /// <param name="offset"></param>
        /// <param name="searchName"></param>
        /// <response code="200">List of categories to which the user has access.</response>
        [HttpGet]
        [Route("/users/{user_id}/access/facilities")]
        [SwaggerOperation("GetAccessUserFacilities")]
        [SwaggerResponse(statusCode: 200, type: typeof(Facility),
            description: "List of categories to which the user has access.")]
        public async Task<IActionResult> GetAccessUserFacilities(
            [FromRoute(Name = "user_id")] [Required]
            string userId,
            [FromQuery(Name = "take")] [Range(1, 100)]
            int? take,
            [FromQuery(Name = "offset")] [Range(0, 100)]
            int? offset
        )
        {
            DynamicUserFacilitySpecification specification = new DynamicUserFacilitySpecification(
                userId: userId,
                take: take,
                offset: offset
            );

            var userFacilities = await _service.GetAccessesAsync(specification);

            return Ok(_mapper.Map<List<UserFacility>>(userFacilities));
        }

        /// <summary>
        /// Creates user access to a facility.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <response code="200">Access to the facility issued.</response>
        [HttpPost]
        [Route("/users/{user_id}/access/facilities")]
        [Consumes("application/json")]
        [SwaggerOperation("GrantUserAccessFacility")]
        public async Task<IActionResult> GrantUserAccessFacility(
            [FromRoute(Name = "user_id")] [Required]
            string userId,
            [FromBody] GrantUserAccessFacilityRequest request
        )
        {
            var model = new GrantAccessFacilityModel(
                FacilityId: request.FacilityId,
                UserId: userId,
                new AccessPeriod(request.StartDate, request.EndDate)
            );

            await _service.GrantAccessAsync(model);

            return Ok();
        }

        /// <summary>
        /// Removes facility access from the user.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="facilityId"></param>
        /// <response code="200">Access to the facility has been successfully removed.</response>
        [HttpDelete]
        [Route("/users/{user_id}/access/facilities/{facility_id}")]
        [SwaggerOperation("RevokeUserAccessFacility")]
        public async Task<IActionResult> RevokeUserAccessFacility(
            [FromRoute(Name = "user_id")] [Required]
            string userId,
            [FromRoute(Name = "facility_id")] [Required]
            Guid facilityId
        )
        {
            var model = new RevokeAccessFacilityModel(
                FacilityId: facilityId,
                UserId: userId
            );

            await _service.RevokeAccessAsync(model);

            return Ok();
        }
    }
}