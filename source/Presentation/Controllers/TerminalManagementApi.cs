/*
 * Facility Access Service API
 *
 * The service an access control system for facilities within the enterprise territory.
 *
 * The version of the OpenAPI document: 1.0.0
 *
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Business.Secure.TerminalScope.Interfaces;
using Domain.TerminalScope.Actions;
using Domain.TerminalScope.Specifications;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Presentation.Controllers;

/// <summary>
/// </summary>
[ApiController]
public class TerminalManagementApiController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ITerminalServiceSecure _service;


    public TerminalManagementApiController(ITerminalServiceSecure service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    /// <summary>
    ///     Creates a terminal and returns it
    /// </summary>
    /// <param name="request"></param>
    /// <response code="200">Terminal</response>
    [HttpPost]
    [Route("/terminals")]
    [Consumes("application/json")]
    [SwaggerOperation("CreateTerminal")]
    [SwaggerResponse(200, type: typeof(Terminal), description: "Terminal")]
    public async Task<IActionResult> CreateTerminal([FromBody] CreateTerminalRequest request)
    {
        var model = new CreateTerminalModel(
            request.Name,
            request.ExpiredTokenOn
        );

        var terminal = await _service.CreateTerminalAsync(model);

        return Ok(_mapper.Map<Terminal>(terminal));
    }

    /// <summary>
    ///     Delete terminal by id
    /// </summary>
    /// <param name="terminalId"></param>
    /// <response code="200">Terminal successfully deleted.</response>
    [HttpDelete]
    [Route("/terminals/{terminal_id}")]
    [SwaggerOperation("DeleteTerminal")]
    public async Task<IActionResult> DeleteTerminal([FromRoute(Name = "terminal_id")] [Required] Guid terminalId)
    {
        var model = new DeleteTerminalModel(terminalId);

        await _service.DeleteTerminalAsync(model);

        return Ok();
    }

    /// <summary>
    ///     Gets a list of all terminals
    /// </summary>
    /// <param name="take"></param>
    /// <param name="offset"></param>
    /// <param name="searchName"></param>
    /// <response code="200">A list of all terminals.</response>
    [HttpGet]
    [Route("/terminals")]
    [SwaggerOperation("GetAllTerminals")]
    [SwaggerResponse(200, type: typeof(List<Terminal>), description: "A list of all terminals.")]
    public async Task<IActionResult> GetAllTerminals(
        [FromQuery(Name = "take")] [Range(1, 100)]
        int? take,
        [FromQuery(Name = "offset")] [Range(0, 100)]
        int? offset,
        [FromQuery(Name = "searchName")] string searchName
    )
    {
        var specification = new DynamicTerminalSpecification(
            take,
            offset,
            searchName
        );

        var terminals = await _service.GetTerminalsAsync(specification);

        return Ok(_mapper.Map<ReadOnlyCollection<Terminal>>(terminals));
    }

    /// <summary>
    ///     Update the terminal partially
    /// </summary>
    /// <param name="terminalId"></param>
    /// <param name="request"></param>
    /// <response code="200">Terminal successfully updated.</response>
    [HttpPatch]
    [Route("/terminals/{terminal_id}")]
    [Consumes("application/json")]
    [SwaggerOperation("UpdateTerminal")]
    [SwaggerResponse(200, type: typeof(Terminal), description: "Terminal successfully updated.")]
    public async Task<IActionResult> UpdateTerminal(
        [FromRoute(Name = "terminal_id")] [Required]
        Guid terminalId,
        [FromBody] UpdateTerminalRequest request
    )
    {
        var model = new UpdateTerminalModel(
            terminalId,
            request.Name,
            request.ExpiredTokenOn
        );

        var terminal = await _service.UpdateTerminalAsync(model);

        return Ok(_mapper.Map<Terminal>(terminal));
    }
}