using System.Threading.Tasks;
using AutoMapper;
using FacilityAccessService.Business.AccessScope.Actions;
using FacilityAccessService.Domain.Secure.AccessScope.Interfaces;
using FacilityAccessService.RestContract.Output.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FacilityAccessService.RestService.Controllers.Access
{
    [ApiController]
    [Route("/access/guard/verify")]
    public class VerifyAccessGuardController : ControllerBase
    {
        private readonly IAccessControlClientServiceSecure _accessControl;
        
        private readonly IMapper _mapper;


        public VerifyAccessGuardController(IAccessControlClientServiceSecure accessControl, IMapper mapper)
        {
            this._accessControl = accessControl;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> VerifyAccess([FromBody] VerifyAccessViaTerminalDTO request)
        {
            VerifyAccessViaGuardModel model = _mapper.Map<VerifyAccessViaGuardModel>(request);

            return await _accessControl.VerifyAccessAsync(model);
        }
    }
}