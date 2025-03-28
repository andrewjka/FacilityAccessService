using AutoMapper;
using FacilityAccessService.Business.TerminalScope.Models;
using FacilityAccessService.Business.TerminalScope.ValueObjects;

namespace FacilityAccessService.RestService.Mapping
{
    public class TerminalMapping : Profile
    {
        public TerminalMapping()
        {
            CreateMap<Terminal, Models.Terminal>()
                .ForMember(dest => dest.Token, opt =>
                    opt.MapFrom(src => src.Token.GetHexFormat())
                );

            CreateMap<Models.Terminal, Terminal>()
                .ForMember(dest => dest.Token, opt =>
                    opt.Ignore())
                .ConstructUsing(src =>
                    new Terminal(src.Name, TerminalToken.GetFromHex(src.Token), src.ExpiredTokenOn));
        }
    }
}