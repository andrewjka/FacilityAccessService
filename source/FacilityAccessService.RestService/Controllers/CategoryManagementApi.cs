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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FacilityAccessService.Business.FacilityScope.Actions;
using FacilityAccessService.Domain.Secure.FacilityScope.Interfaces;
using FacilityAccessService.RestService.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

#endregion

namespace FacilityAccessService.RestService.Controllers
{
    /// <summary>
    /// </summary>
    [ApiController]
    public class CategoryManagementApiController : ControllerBase
    {
        private readonly ICategoryServiceSecure _service;


        public CategoryManagementApiController(ICategoryServiceSecure service)
        {
            _service = service;
        }

        /// <summary>
        ///     Creates a category and returns it.
        /// </summary>
        /// <param name="request"></param>
        /// <response code="200">Category.</response>
        [HttpPost]
        [Route("/categories")]
        [Consumes("application/json")]
        [SwaggerOperation("CreateCategory")]
        [SwaggerResponse(200, type: typeof(Category), description: "Category.")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
        {
            CreateCategoryModel model = new CreateCategoryModel(
                Name: request.Name,
                FacilitiesId: request.Facilities.ToHashSet()
            );

            return Ok(await _service.CreateCategoryAsync(model));
        }

        /// <summary>
        ///     Deletes category by id.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Category successfully deleted.</response>
        [HttpDelete]
        [Route("/categories/{id}")]
        [SwaggerOperation("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory([FromRoute(Name = "id")] [Required] Guid id)
        {
            DeleteCategoryModel model = new DeleteCategoryModel(
                CategoryId: id
            );

            await _service.DeleteCategoryAsync(model);

            return Ok();
        }

        /// <summary>
        ///     Returns all categories according to the conditions.
        /// </summary>
        /// <param name="take"></param>
        /// <param name="offset"></param>
        /// <param name="name"></param>
        /// <response code="200">A list of categories that match the provided query parameters.</response>
        [HttpGet]
        [Route("/categories")]
        [SwaggerOperation("GetAllCategories")]
        [SwaggerResponse(200, type: typeof(List<Category>),
            description: "A list of categories that match the provided query parameters.")]
        public async Task<IActionResult> GetAllCategories(
            [FromQuery(Name = "take")] [Range(1, 100)]
            decimal? take,
            [FromQuery(Name = "offset")] [Range(1, 100)]
            decimal? offset,
            [FromQuery(Name = "searchName")] string searchName)

        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Updates a category partially.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <response code="200">Category successfully updated..</response>
        [HttpPatch]
        [Route("/categories/{id}")]
        [Consumes("application/json")]
        [SwaggerOperation("UpdateCategory")]
        [SwaggerResponse(200, type: typeof(Category), description: "Category successfully updated..")]
        public async Task<IActionResult> UpdateCategory(
            [FromRoute(Name = "id")] [Required] Guid id,
            [FromBody] UpdateCategoryRequest request
        )
        {
            UpdateCategoryModel model = new UpdateCategoryModel(
                CategoryId: id,
                Name: request.Name,
                FacilitiesId: request.Facilities?.ToHashSet()
            );

            return Ok(await _service.UpdateCategoryAsync(model));
        }
    }
}