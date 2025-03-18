using System.Threading.Tasks;
using AutoMapper;
using FacilityAccessService.Business.AccessScope.Actions;
using FacilityAccessService.Domain.Secure.AccessScope.Interfaces;
using FacilityAccessService.RestContract.Output.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FacilityAccessService.RestService.Controllers.Access
{
    [ApiController]
    [Route("/access/terminal/verify")]
    public class VerifyAccessTerminalController : ControllerBase
    {
        private readonly IAccessControlTerminalServiceSecure _accessControl;

        private readonly IMapper _mapper;


        public VerifyAccessTerminalController(IAccessControlTerminalServiceSecure accessControl, IMapper mapper)
        {
            this._accessControl = accessControl;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> VerifyAccess([FromBody] VerifyAccessViaTerminalDTO request)
        {
            VerifyAccessViaTerminalModel model = _mapper.Map<VerifyAccessViaTerminalModel>(request);

            return await _accessControl.VerifyAccessAsync(model);
        }
    }
}