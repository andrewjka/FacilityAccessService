using AutoMapper;
using FacilityAccessService.Business.TerminalScope.Models;

namespace FacilityAccessService.Persistence.TerminalScope.Mapping
{
    public class TerminalMapping : Profile
    {
        public TerminalMapping()
        {
            CreateMap<Terminal, Models.Terminal>();
            CreateMap<Models.Terminal, Terminal>();
        }
    }
}